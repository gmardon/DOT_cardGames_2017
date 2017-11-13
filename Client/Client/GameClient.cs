using System;
using System.Collections.Generic;
using Ether.Network;
using Ether.Network.Packets;
using Poker.Core.Cards;
using Poker.Core.IO;
using Poker.Core.Protocol;

namespace Poker.Client
{
    class GameClient : NetClient
    {
        string username;
        List<string> players { get; }
        int money { set; get; }
        Card firstCard { set;  get; }
        Card secondCard { set; get; }

        public delegate void onConnected();

        private onConnected onConnectedCallback = null;

        public GameClient(string host, int port, string username, int bufferSize) : base(host, port, bufferSize)
        {
            players = new List<string>();
            this.username = username;
        }

        protected override void HandleMessage(NetPacketBase packet)
        {
            int id = packet.Read<int>();
            Console.WriteLine("-> Server response: {0}", id);
        }

        public void Send(ProtocolMessage message)
        {
            using (var packet = new NetPacket())
            {
                packet.Write(message.id);
                packet.Write(RawObjectWriter.Save(message));
                this.Send(packet);
            }
        }

        protected override void OnConnected()
        {
            onConnectedCallback?.Invoke();
            Send(new HelloConnectMessage().Init(username));
            Console.WriteLine("Connected to {0}", this.Socket.RemoteEndPoint.ToString());
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine("Disconnected");
        }

        private void addPlayer(string name)
        {
            players.Add(name);
        }

        private void setCards(Card firstCard, Card secondCard)
        {
            this.firstCard = firstCard;
            this.secondCard = secondCard;
        }
    
        public void setOnConnectedCallback(onConnected callback)
        {
            this.onConnectedCallback = callback;
        }
    }
}
