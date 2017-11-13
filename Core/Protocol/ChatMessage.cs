using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class ChatMessage : ProtocolMessage
    {
        public new const int ID = 2;

        [DataMember] private string msg { get; }

        public ChatMessage(string msg) : base(ID)
        {
            this.msg = msg;
        }
    }
}
