using System.Collections.Generic;

namespace Poker.Core.Players
{
    public interface IStartGameContext
    {
        IReadOnlyCollection<string> PlayerNames { get; }
        int StartMoney { get; }
    }
}