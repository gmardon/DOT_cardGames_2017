using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class PlayerReadyMessage : ProtocolMessage
    {
        [DataMember] public new const int ID = 4;

        [DataMember] public string username
        {
            get;
            set;
        }

        public PlayerReadyMessage() : base(ID)
        {
            
        }

        public PlayerReadyMessage Init()
        {
            return this;
        }
    }
}
