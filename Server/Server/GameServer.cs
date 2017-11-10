using Ether.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Poker.Core.GameMechanics;
using Poker.Core.Protocol;

namespace Poker.Server
{
    class GameServer : NetServer<GameClient>
    {
        List<GameClient> clients;

        public GameServer()
        {
            // Configure the server
            this.Configuration.Backlog = 100;
            this.Configuration.Port = 8888;
            this.Configuration.MaximumNumberOfConnections = 100;
            this.Configuration.Host = "127.0.0.1";
            this.clients = new List<GameClient>();
        }

        protected override void Initialize()
        {
            Console.WriteLine("Server is ready.");
        }

        protected override void OnClientConnected(GameClient connection)
        {
            Console.WriteLine("New client connected!");
            clients.Add(connection);
        }

        protected override void OnClientDisconnected(GameClient connection)
        {
            Console.WriteLine("Client disconnected!");
        }

        private void Broadcast(ProtocolMessage message)
        {
            foreach (GameClient client in clients)
            {
                client.Send(message);
            }
        }

        private void StartGame()
        {
            //ITexasHoldemGame game;

            //create game

            //GameThreadHandle handle = new GameThreadHandle(game);
            //Thread GameThread = new Thread(new ThreadStart(handle.ThreadLoop));
            
        }
    }

    class GameThreadHandle
    {
        ITexasHoldemGame game;

        public GameThreadHandle(ITexasHoldemGame game)
        {
            this.game = game;
        }

        public void ThreadLoop()
        {
            game.Start();
        }
    }
}
