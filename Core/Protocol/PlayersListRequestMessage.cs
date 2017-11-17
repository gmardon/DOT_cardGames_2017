using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class PlayersListRequestMessage : ProtocolMessage
    {
        public new const int ID = 7;

        public PlayersListRequestMessage() : base(ID)
        { }
    }
}
