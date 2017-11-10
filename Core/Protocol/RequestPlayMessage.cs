using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    class RequestPlayMessage : ProtocolMessage
    {
        [DataMember] public new const int ID = 3;
    }
}
