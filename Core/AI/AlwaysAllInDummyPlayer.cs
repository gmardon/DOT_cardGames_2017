using System;
using Poker.Core.Players;

namespace Poker.Core.AI
{
    internal class AlwaysAllInDummyPlayer : BasePlayer
    {
        public override string Name { get; } = "AlwaysAllInDummyPlayer_" + Guid.NewGuid();

        public override PlayerAction GetTurn(IGetTurnContext context)
        {
            if (context.MoneyLeft > 0)
            {
                return PlayerAction.Raise(context.MoneyLeft);
            }
            else
            {
                return PlayerAction.CheckOrCall();
            }
        }
    }
}
