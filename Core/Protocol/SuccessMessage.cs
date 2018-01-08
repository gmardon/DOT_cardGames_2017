using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class SuccessMessage : ProtocolMessage
    {
        public new const int ID = 9;

        [DataMember]
        private string msg { get; set; }

        public SuccessMessage() : base(ID)
        { }

        public SuccessMessage Init(string msg)
        {
            this.msg = msg;
            return this;
        }
    }
}
