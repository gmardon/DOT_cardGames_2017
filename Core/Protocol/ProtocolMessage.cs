using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public abstract class ProtocolMessage
    {
        [DataMember] public int ID;

        public ProtocolMessage(int ID)
        {
            this.ID = ID;
        }
    }
}
