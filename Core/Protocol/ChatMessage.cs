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

        [DataMember] private string user { get; set; }
        [DataMember] private string msg { get; set; }

        public ChatMessage() : base(ID)
        {}

        public ChatMessage Init(string user, string msg)
        {
            this.user = user;
            this.msg = msg;
            return this;
        }
    }
}
