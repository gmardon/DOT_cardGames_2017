namespace Poker.Core.Helpers
{
    using System.Collections.Generic;

    using Poker.Core.Cards;

    public interface IHandEvaluator
    {
        BestHand GetBestHand(IEnumerable<Card> cards);
    }
}