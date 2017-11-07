using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Ether.Network.Packets;

namespace Core.Protocol
{
    [DataContract]
    public abstract class ProtocolMessage
    {
        [DataMember] public int ID = 0;
    }
}
