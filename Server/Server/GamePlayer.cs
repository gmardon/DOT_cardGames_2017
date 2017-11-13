using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Core.Players;

namespace Poker.Server.Server
{
    class GamePlayer : BasePlayer
    {
        private GameClient Client;

        public GamePlayer(GameClient client, string username)
        {
            this.Client = client;
            this.Name = username;
        }

        public override string Name { get; }
        public override PlayerAction GetTurn(IGetTurnContext context)
        {
            throw new NotImplementedException();
        }
    }
}
