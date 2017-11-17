using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class PlayerTurnBeginMessage : ProtocolMessage
    {
        public new const int ID = 5;

        public PlayerTurnBeginMessage() : base(ID)
        { }
    }
}
