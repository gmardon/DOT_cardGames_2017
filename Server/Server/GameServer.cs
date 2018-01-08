using Ether.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Core.GameMechanics;
using Poker.Core.Players;
using Poker.Core.Protocol;
using Poker.Server.Game;
using Poker.Server.Server;

namespace Poker.Server
{
    public class GameServer : NetServer<GameClient>
    {
        public List<GameClient> Clients { get; }

        public List<IPlayer> Players;

        ITexasHoldemGame Game;

        public GameServer()
        {
            // Configure the server
            this.Configuration.Backlog = 100;
            this.Configuration.Port = 8888;
            this.Configuration.MaximumNumberOfConnections = 100;
            this.Configuration.Host = "127.0.0.1";
            this.Clients = new List<GameClient>();
        }

        protected override void Initialize()
        {
            Console.WriteLine("Server is ready.");
        }

        protected override void OnClientConnected(GameClient connection)
        {
            Console.WriteLine("New client connected!");
            connection.broadcast = Broadcast;
            connection.onReady = onClientReady;
            connection.Server = this;
            Clients.Add(connection);
        }

        private void onClientReady()
        {
            if (Clients.All(client => client.State == GameClient.GameClientState.Ready))
            {
                Players = new List<IPlayer>();
                foreach (GameClient client in Clients)
                {
                    Players.Add(new GamePlayerDecorator(client.Player, client, this));
                }
                MultiPlayersTexasHoldemGame game = new MultiPlayersTexasHoldemGame(Players);
                game.Start();
            }
        }

        protected override void OnClientDisconnected(GameClient connection)
        {
            Console.WriteLine("Client disconnected!");
            Clients.Remove(connection);
        }

        public void Broadcast(ProtocolMessage message)
        {
            foreach (GameClient client in Clients)
            {
                client.Send(message);
            }
        }

        public void BroadcastExcept(ProtocolMessage message, GameClient client)
        {
            foreach (GameClient it in Clients)
            {
                if (it != client)
                    it.Send(message);
            }
        }
    }
}
