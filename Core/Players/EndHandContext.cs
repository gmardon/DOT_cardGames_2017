namespace Poker.Core.Players
{
    using System.Collections.Generic;
    using Poker.Core.Cards;

    public class EndHandContext : IEndHandContext
    {
        public EndHandContext(Dictionary<string, ICollection<Card>> showdownCards)
        {
            this.ShowdownCards = showdownCards;
        }

        public Dictionary<string, ICollection<Card>> ShowdownCards { get; private set; }
    }
}