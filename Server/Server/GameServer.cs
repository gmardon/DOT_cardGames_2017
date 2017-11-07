using Ether.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Server
{
    class GameServer : NetServer<GameClient>
    {
        public GameServer()
        {
            // Configure the server
            this.Configuration.Backlog = 100;
            this.Configuration.Port = 8888;
            this.Configuration.MaximumNumberOfConnections = 100;
            this.Configuration.Host = "127.0.0.1";
        }

        protected override void Initialize()
        {
            Console.WriteLine("Server is ready.");
        }

        protected override void OnClientConnected(GameClient connection)
        {
            Console.WriteLine("New client connected!");
        }

        protected override void OnClientDisconnected(GameClient connection)
        {
            Console.WriteLine("Client disconnected!");
        }
    }
}
