using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class UpdatePotMessage : ProtocolMessage
    {
        public new const int ID = 10;

        [DataMember]
        private int pot { get; set; }

        public UpdatePotMessage() : base(ID)
        { }

        public UpdatePotMessage Init(int pot)
        {
            this.pot = pot;
            return this;
        }
    }
}
