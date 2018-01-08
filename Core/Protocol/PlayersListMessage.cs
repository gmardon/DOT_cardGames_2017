using System.Collections.Generic;
using System.Runtime.Serialization;
using Poker.Core.Players;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class PlayersListMessage : ProtocolMessage
    {
        [DataMember] private List<IPlayer> players;
        public new const int ID = 6;

        public PlayersListMessage() : base(ID)
        { }

        public PlayersListMessage Init(List<IPlayer> players)
        {
            this.players = players;
            return this;
        }
    }
}
