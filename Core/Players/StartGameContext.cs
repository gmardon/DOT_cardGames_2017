using System.Collections.Generic;

namespace Poker.Core.Players
{
    public class StartGameContext : IStartGameContext
    {
        public StartGameContext(IReadOnlyCollection<string> playerNames, int startMoney)
        {
            this.PlayerNames = playerNames;
            this.StartMoney = startMoney;
        }

        public IReadOnlyCollection<string> PlayerNames { get; }

        public int StartMoney { get; }
    }
}
