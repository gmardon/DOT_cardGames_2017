using Poker.Core.Players;
using Poker.Core.Protocol;
using Poker.Core.Cards;
using System.Collections.Generic;

namespace Poker.Server.Server
{
    class GamePlayerDecorator : PlayerDecorator
    {
        GameServer server;
        GameClient client;

        private IReadOnlyCollection<Card> CommunityCards { get; set; }
        public GamePlayerDecorator(GamePlayer player, GameClient client, GameServer server) : base(player)
        {
            this.client = client;
            this.server = server;
        }

        public void Broadcast(ProtocolMessage message)
        {
            server.Broadcast(message);
        }

        public void BroadcastExcept(ProtocolMessage message)
        {
            server.BroadcastExcept(message, client);
        }

        public void Send(ProtocolMessage message)
        {
            client.Send(message);
        }

        public override void StartHand(IStartHandContext context)
        {
            BroadcastExcept(new ChatMessage().Init("System", Player.Name + " is the dealer"));
            Send(new ChatMessage().Init("System", "You are the dealer !"));

            Send(new PlayerCardsMessage().Init(context.FirstCard, context.SecondCard));

            base.StartHand(context);
        }

        public override void StartRound(IStartRoundContext context)
        {
            this.CommunityCards = context.CommunityCards;

            Broadcast(new UpdatePotMessage().Init(context.CurrentPot));

            base.StartRound(context);
        }
    }
}
