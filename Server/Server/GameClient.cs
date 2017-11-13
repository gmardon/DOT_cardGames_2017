using System;
using Poker.Core.IO;
using Poker.Core.Protocol;
using Ether.Network;
using Ether.Network.Packets;
using Poker.Core.Players;
using Poker.Server.Server;

namespace Poker.Server
{
    class GameClient : NetConnection
    {
        public enum GameClientState { Undefined, Connected, Ready };
        public delegate void Broadcast(ProtocolMessage message);
        public delegate void OnReady();

        public Broadcast broadcast { set; get; }
        public OnReady onReady { set; get; }

        private GamePlayer Player { set; get; }

        public GameClientState State { set; get; }

        public GameClient()
        {
            this.State = GameClientState.Undefined;
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
        
        public override void HandleMessage(NetPacketBase packet)
        {
            int id = packet.Read<int>();
            string content = packet.Read<string>();
            ProtocolMessage message = null;
            switch (id)
            {
                case HelloConnectMessage.ID:
                    message = RawObjectReader.Load<HelloConnectMessage>(content);
                    handleHelloConnectMessage((HelloConnectMessage) message);
                    break;
                case PlayerReadyMessage.ID:
                    message = RawObjectReader.Load<PlayerReadyMessage>(content);
                    handlePlayerReadyMessage((PlayerReadyMessage)message);
                    break;
                case ChatMessage.ID:
                    broadcast(message);
                    break;
                default:
                    throw new Exception("Message " + id + " is not implemented");
            }
            Console.WriteLine("Received '{1}' from {0}", this.Id, content);
        }

        public void handleHelloConnectMessage(HelloConnectMessage message)
        {
            Console.WriteLine("User {0} just joined !", message.username);
            Player = new GamePlayer(this, message.username);
        }

        public void handlePlayerReadyMessage(PlayerReadyMessage message)
        {
            this.State = GameClientState.Ready;
            onReady();
        }
    }
}