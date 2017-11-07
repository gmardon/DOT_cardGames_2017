using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protocol
{
    [DataContract]
    public class HelloConnectMessage : ProtocolMessage
    {
        [DataMember]
        public new const int ID = 1;
    }
}
