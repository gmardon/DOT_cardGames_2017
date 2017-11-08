using System.Collections.Generic;
using Poker.Core.Cards;

namespace Poker.Core.Players
{
    public interface IStartRoundContext
    {
        IReadOnlyCollection<Card> CommunityCards { get; }
        int CurrentPot { get; }
        int MoneyLeft { get; }
        GameRoundType RoundType { get; }
    }
}