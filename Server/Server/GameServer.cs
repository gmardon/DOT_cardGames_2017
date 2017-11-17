using Ether.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Poker.Core.GameMechanics;
using Poker.Core.Players;
using Poker.Core.Protocol;
using Poker.Server.Game;
using Poker.Server.Server;

namespace Poker.Server
{
    class GameServer : NetServer<GameClient>
    {
        public List<GameClient> Clients { get; }

        public List<BasePlayer> BasePlayers => new List<BasePlayer>(from client in Clients select client.Player);

        ITexasHoldemGame Game;

        public GameServer()
        {
            // Configure the server
            this.Configuration.Backlog = 100;
            this.Configuration.Port = 4268;
            this.Configuration.MaximumNumberOfConnections = 100;
            this.Configuration.Host = "127.0.0.1";
            this.Clients = new List<GameClient>();
        }

        protected override void Initialize()
        {
            Console.WriteLine("Server is ready.");
        }

        protected override void OnClientConnected(GameClient connection)
        {
            Console.WriteLine("New client connected!");
            connection.broadcast = Broadcast;
            connection.onReady = onClientReady;
            connection.Server = this;
            Clients.Add(connection);
        }

        private void onClientReady()
        {
            if (Clients.All(client => client.State == GameClient.GameClientState.Ready))
            {
                // BEGIN GAME !
            }
        }

        protected override void OnClientDisconnected(GameClient connection)
        {
            Console.WriteLine("Client disconnected!");
        }

        public void Broadcast(ProtocolMessage message)
        {
            foreach (GameClient client in Clients)
            {
                client.Send(message);
            }
        }
    }
}
