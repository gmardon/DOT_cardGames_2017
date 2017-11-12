using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class HelloConnectMessage : ProtocolMessage
    {
        [DataMember]
        public new const int ID = 1;
    }
}
