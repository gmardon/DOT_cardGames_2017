using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class RequestPlayMessage : ProtocolMessage
    {
        public new const int ID = 3;

        public RequestPlayMessage() : base(ID)
        { }
    }
}
