using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Poker.Core.Players;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class PlayersListMessage : ProtocolMessage
    {
        [DataMember] private List<BasePlayer> players;
        public new const int ID = 6;

        public PlayersListMessage() : base(ID)
        { }

        public PlayersListMessage Init(List<BasePlayer> players)
        {
            this.players = players;
            return this;
        }
    }
}
