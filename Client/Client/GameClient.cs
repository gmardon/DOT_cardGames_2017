using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ether.Network;
using Ether.Network.Packets;

namespace Poker.Client
{
    class GameClient : NetClient
    {
        public GameClient(string host, int port, int bufferSize) : base(host, port, bufferSize)
        {
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
