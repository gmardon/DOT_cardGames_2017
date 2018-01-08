using Poker.Core.Players;
using Poker.Core.Protocol;
using System.Threading;
using System;

namespace Poker.Server.Server
{
    public class GamePlayer : BasePlayer
    {
        public GameClient Client;

        public GamePlayer(GameClient client, string username)
        {
            this.Client = client;
            this.Name = username;
        }

        public override string Name { get; }
        public override PlayerAction GetTurn(IGetTurnContext context)
        {
            Client.Send(new PlayerTurnBeginMessage());
            while (true)
            {
                var playerAction = Client.playerAction;
                Client.playerAction = null;
                switch (playerAction)
                {
                    case "check":
                        return PlayerAction.CheckOrCall();
                    case "raise":
                        return PlayerAction.Raise(10);
                    case "fold":
                        return PlayerAction.Fold();
                    case "allin":
                        return context.MoneyLeft > 0
                                         ? PlayerAction.Raise(context.MoneyLeft)
                                         : PlayerAction.CheckOrCall();
                    default:
                        continue;
                }
            }
        }
    }
}
