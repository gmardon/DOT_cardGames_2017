using System;
using System.Collections.Generic;
using Ether.Network;
using Ether.Network.Packets;
using Poker.Core.Cards;

namespace Poker.Client
{
    class GameClient : NetClient
    {
        string username;
        List<string> players;
        Card firstCard;
        

        public GameClient(string host, int port, string username, int bufferSize) : base(host, port, bufferSize)
        {
            this.username = username;
        }

        protected override void HandleMessage(NetPacketBase packet)
        {
            int id = packet.Read<int>();


            Console.WriteLine("-> Server response: {0}", id);
        }

        protected override void OnConnected()
        {
            Console.WriteLine("Connected to {0}", this.Socket.RemoteEndPoint.ToString());
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine("Disconnected");
        }
    }
}
