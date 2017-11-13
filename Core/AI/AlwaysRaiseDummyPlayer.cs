using System;
using Poker.Core.Players;

namespace Poker.Core.AI
{
    internal class AlwaysRaiseDummyPlayer : BasePlayer
    {
        public override string Name { get; } = "AlwaysRaiseDummyPlayer_" + Guid.NewGuid();

        public override PlayerAction GetTurn(IGetTurnContext context)
        {
            return PlayerAction.Raise(context.SmallBlind);
        }
    }
}
