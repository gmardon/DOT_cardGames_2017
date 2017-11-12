using System.Collections.Generic;
using Poker.Core.Cards;

namespace Poker.Core.Players
{
    public class StartRoundContext : IStartRoundContext
    {
        public StartRoundContext(GameRoundType roundType, IReadOnlyCollection<Card> communityCards, int moneyLeft, int currentPot)
        {
            this.RoundType = roundType;
            this.CommunityCards = communityCards;
            this.MoneyLeft = moneyLeft;
            this.CurrentPot = currentPot;
        }

        public GameRoundType RoundType { get; }

        public IReadOnlyCollection<Card> CommunityCards { get; }

        public int MoneyLeft { get; }

        public int CurrentPot { get; }
    }
}
