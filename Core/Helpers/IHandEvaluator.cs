using System.Collections.Generic;
using Poker.Core.Cards;

namespace Poker.Core.Helpers
{
    public interface IHandEvaluator
    {
        BestHand GetBestHand(IEnumerable<Card> cards);
    }
}