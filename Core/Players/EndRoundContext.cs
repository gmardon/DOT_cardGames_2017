using System.Collections.Generic;

namespace Poker.Core.Players
{
    public class EndRoundContext : IEndRoundContext
    {
        public EndRoundContext(IReadOnlyCollection<PlayerActionAndName> roundActions)
        {
            this.RoundActions = roundActions;
        }

        public IReadOnlyCollection<PlayerActionAndName> RoundActions { get; }
    }
}
