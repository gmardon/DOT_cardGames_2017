using System;
using System.Collections.Generic;
using Ether.Network;
using Ether.Network.Packets;
using Poker.Core.Cards;
using Poker.Core.IO;
using Poker.Core.Protocol;
using System.Threading;

namespace Poker.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new GameClient("127.0.0.1", 8888, 4096);
            client.Connect();

            string username = null;
            while (!client.Logged)
            {
                Console.WriteLine("Enter a username to log in");
                username = Console.ReadLine();
                client.Send(new HelloConnectMessage().Init(username));
            }

            client.Username = username;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "/quit") break;

                switch (input)
                {
                    case "/check":
                        client.Send(new PlayerActionMessage().Init("check"));
                        break;
                    case "/raise":
                        client.Send(new PlayerActionMessage().Init("raise"));
                        break;
                    case "/fold":
                        client.Send(new PlayerActionMessage().Init("fold"));
                        break;
                    case "/allin":
                        client.Send(new PlayerActionMessage().Init("allin"));
                        break;
                    case "/info":
                        Console.WriteLine();
                        break;
                    default:
                        client.Send(new ChatMessage().Init(input));
                        break;
                }
            }

            client.Disconnect();
        }
    }

    class GameClient : NetClient
    {
        public string Username { get; set; }
        List<string> Players { get; }
        int Money { set; get; }
        Card FirstCard { set; get; }
        Card SecondCard { set; get; }
        public bool Logged { get; }

        public delegate void onConnected();

        private onConnected onConnectedCallback = null;

        public GameClient(string host, int port, int bufferSize) : base(host, port, bufferSize)
        {
            Players = new List<string>();
            Logged = false;
        }

        protected override void HandleMessage(NetPacketBase packet)
        {
            int id = packet.Read<int>();
            Console.WriteLine("-> Server response: {0}", id);
            switch (id)
            {
                case PlayerTurnBeginMessage.id:
                    Console.WriteLine("It's your turn !");
                    break;
                
            }
        }

        public void Send(ProtocolMessage message)
        {
            using (var packet = new NetPacket())
            {
                packet.Write(message.ID);
                packet.Write(RawObjectWriter.Save(message));
                this.Send(packet);
            }
        }

        protected override void OnConnected()
        {
            onConnectedCallback?.Invoke();
            Send(new HelloConnectMessage().Init(Username));
            Console.WriteLine("Connected to {0}", this.Socket.RemoteEndPoint.ToString());
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine("Disconnected");
        }

        private void AddPlayer(string name)
        {
            Players.Add(name);
        }

        private void SetCards(Card firstCard, Card secondCard)
        {
            this.FirstCard = firstCard;
            this.SecondCard = secondCard;
        }
    
        public void SetOnConnectedCallback(onConnected callback)
        {
            this.onConnectedCallback = callback;
        }
    }
}
