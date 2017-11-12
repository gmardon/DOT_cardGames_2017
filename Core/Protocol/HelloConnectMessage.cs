using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class HelloConnectMessage : ProtocolMessage
    {
        [DataMember] public new const int ID = 1;

        [DataMember] public string username
        {
            get;
            set;
        }

        public HelloConnectMessage() : base(ID)
        {
            
        }

        public HelloConnectMessage Init(string username)
        {
            this.username = username;
            return this;
        }
    }
}
