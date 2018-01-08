using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class ErrorMessage : ProtocolMessage
    {
        public new const int ID = 8;

        [DataMember]
        private string msg { get; set; }

        public ErrorMessage() : base(ID)
        { }

        public ErrorMessage Init(string msg)
        {
            this.msg = msg;
            return this;
        }
    }
}
