using System.Collections.Generic;

namespace Poker.Core.Players
{
    public interface IEndRoundContext
    {
        IReadOnlyCollection<PlayerActionAndName> RoundActions { get; }
    }
}