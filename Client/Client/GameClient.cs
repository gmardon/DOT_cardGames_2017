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


            if (!client.ready)
                Thread.Sleep(1);
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "/quit") break;

                switch (input)
                {
                    case "/ready":
                        client.Send(new PlayerReadyMessage().Init());
                        break;
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
                        client.Send(new ChatMessage().Init(client.Username, input));
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
        public bool ready { get; set; }

        public GameClient(string host, int port, int bufferSize) : base(host, port, bufferSize)
        {
            Players = new List<string>();
            ready = false;
        }

        protected override void HandleMessage(NetPacketBase packet)
        {
            int id = packet.Read<int>();
            Console.WriteLine("-> Server response: {0}", id);
            switch (id)
            {
                case PlayerTurnBeginMessage.ID:
                    Console.WriteLine("It's your turn !");
                    break;
                case ChatMessage.ID:
                    Console.WriteLine(packet.Read<string>());
                    break;
                case PlayerCardsMessage.ID:
                    Console.WriteLine(packet.Read<string>());
                    break;
                case UpdatePotMessage.ID:
                    Console.WriteLine("Pot is : {0}", packet.Read<int>());
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
            string username = null;
            Console.WriteLine("Enter a username to log in :");
            username = Console.ReadLine();
            ready = true;
            Send(new HelloConnectMessage().Init(username));
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

    }
}
