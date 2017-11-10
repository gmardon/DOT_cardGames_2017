using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    class ChatMessage : ProtocolMessage
    {
        [DataMember] public new const int ID = 2;
        [DataMember] private string msg { get; }

        public ChatMessage(string msg)
        {
            this.msg = msg;
        }
    }
}
