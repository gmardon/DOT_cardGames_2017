namespace Poker.Core.Players
{
    using Poker.Core.Cards;

    public class StartHandContext : IStartHandContext
    {
        public StartHandContext(Card firstCard, Card secondCard, int handNumber, int moneyLeft, int smallBlind, string firstPlayerName)
        {
            this.FirstCard = firstCard;
            this.SecondCard = secondCard;
            this.HandNumber = handNumber;
            this.MoneyLeft = moneyLeft;
            this.SmallBlind = smallBlind;
            this.FirstPlayerName = firstPlayerName;
        }

        public Card FirstCard { get; }

        public Card SecondCard { get; }

        public int HandNumber { get; }

        public int MoneyLeft { get; }

        public int SmallBlind { get; }

        public string FirstPlayerName { get; }
    }
}
