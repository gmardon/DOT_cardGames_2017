using System.Runtime.Serialization;
using Poker.Core.Cards;

namespace Poker.Core.Protocol
{
    [DataContract]
    public class PlayerCardsMessage : ProtocolMessage
    {
        [DataMember] public new const int ID = 11;

        [DataMember] public Card firstCard { get; set; }
        [DataMember] public Card secondCard { get; set; }
        public PlayerCardsMessage() : base(ID)
        { }

        public PlayerCardsMessage Init(Card firstCard, Card secondCard)
        {
            this.firstCard = firstCard;
            this.secondCard = secondCard;
            return this;
        }
    }
}
