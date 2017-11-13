using System;
using Poker.Core.Players;

namespace Poker.Core.AI
{
    internal class AlwaysCallDummyPlayer : BasePlayer
    {
        public override string Name { get; } = "AlwaysCallDummyPlayer_" + Guid.NewGuid();

        public override PlayerAction GetTurn(IGetTurnContext context)
        {
            return PlayerAction.CheckOrCall();
        }
    }
}
