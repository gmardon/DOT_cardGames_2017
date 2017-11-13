using System;
using Poker.Core.Players;

namespace Poker.Core.AI
{
    internal class AlwaysFoldDummyPlayer : BasePlayer
    {
        public override string Name { get; } = "AlwaysFoldDummyPlayer_" + Guid.NewGuid();

        public override PlayerAction GetTurn(IGetTurnContext context)
        {
            return PlayerAction.Fold();
        }
    }
}
