﻿namespace Poker.Core.Players
{
    using System.Collections.Generic;

    public class EndRoundContext : IEndRoundContext
    {
        public EndRoundContext(IReadOnlyCollection<PlayerActionAndName> roundActions)
        {
            this.RoundActions = roundActions;
        }

        public IReadOnlyCollection<PlayerActionAndName> RoundActions { get; }
    }
}
