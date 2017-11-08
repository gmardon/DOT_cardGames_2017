namespace Poker.Core.Players
{
    public class EndGameContext : IEndGameContext
    {
        public EndGameContext(string winnerName)
        {
            this.WinnerName = winnerName;
        }

        public string WinnerName { get; }
    }
}
