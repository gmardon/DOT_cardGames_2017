using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class PlayerActionMessage : ProtocolMessage
    {
        public new const int ID = 3;

        [DataMember] private string action { get; }

        public PlayerActionMessage(string action) : base(ID)
        {
            this.action = action;
        }
    }
}
