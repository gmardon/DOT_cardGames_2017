using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Core.Players;
using Poker.Core.Protocol;

namespace Poker.Core.Players
{
    class NetworkPlayer
    {
        public override string Name { get; }

        public delegate void Send(ProtocolMessage message);

        public NetworkPlayer(string Name)
        {
            this.Name = Name;
        }

        public override PlayerAction GetTurn(IGetTurnContext context)
        {
            PlayerAction action = null;

            while (true)
            {
                Send(new RequestPlayMessage());

                //wait for response

                if (action != null)
                    return action;
            }
        }
    }
}
