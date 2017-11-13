using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Core.Players;

namespace Poker.Server.Server
{
    class GamePlayerDecorator : PlayerDecorator
    {
        public GamePlayerDecorator(GamePlayer player) : base(player)
        {
            
        }
    }
}
