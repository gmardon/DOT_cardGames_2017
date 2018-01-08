using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Core.GameMechanics;
using Poker.Core.Players;
using Poker.Core.Protocol;

namespace Poker.Server.Game
{
    public class MultiPlayersTexasHoldemGame : ITexasHoldemGame
    {
        private static readonly int[] SmallBlinds =
            {
                1, 2, 3, 5, 10, 15, 20, 25, 30, 40, 50, 60, 80, 100, 150, 200, 300,
                400, 500, 600, 800, 1000, 1500, 2000, 3000, 4000, 5000, 6000, 8000,
                10000, 15000, 20000, 30000, 40000, 50000, 60000, 80000, 100000
            };

        private readonly ICollection<InternalPlayer> allPlayers;

        private readonly int initialMoney;

        public MultiPlayersTexasHoldemGame(List<IPlayer> players, int initialMoney = 1000)
        {
            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            if (initialMoney <= 0 || initialMoney > 200000)
            {
                throw new ArgumentOutOfRangeException(nameof(initialMoney), "Initial money should be greater than 0 and less than 200000");
            }

            this.allPlayers = new List<InternalPlayer>();

            foreach (IPlayer player in players)
            {
                allPlayers.Add(new InternalPlayer(player));
            }

            this.initialMoney = initialMoney;
            this.HandsPlayed = 0;
        }

        public int HandsPlayed { get; private set; }

        public IPlayer Start()
        {
            var playerNames = this.allPlayers.Select(x => x.Name).ToList().AsReadOnly();
            foreach (var player in this.allPlayers)
            {
                player.StartGame(new StartGameContext(playerNames, this.initialMoney));
            }

            // While at least two players have money
            while (this.allPlayers.Count(x => x.PlayerMoney.Money > 0) > 1)
            {
                this.HandsPlayed++;

                // Every 10 hands the blind increases
                var smallBlind = SmallBlinds[(this.HandsPlayed - 1) / 10];

                // Rotate players
                int offset = this.HandsPlayed % allPlayers.Count();

                var tmp = allPlayers.ToArray();
                var players = new List<InternalPlayer>();
                for (int ctr = 0; ctr < allPlayers.Count(); ctr++)
                {
                    players.Add(tmp[(ctr + offset) % allPlayers.Count()]);
                }

                IHandLogic hand = new MultiPlayersHandLogic(players, this.HandsPlayed, smallBlind);

                hand.Play();
            }

            var winner = this.allPlayers.FirstOrDefault(x => x.PlayerMoney.Money > 0);
            foreach (var player in this.allPlayers)
            {
                player.EndGame(new EndGameContext(winner.Name));
            }

            return winner;
        }
    }
}
