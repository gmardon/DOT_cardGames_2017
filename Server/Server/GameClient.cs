using System;
using Poker.Core.IO;
using Poker.Core.Protocol;
using Ether.Network;
using Ether.Network.Packets;

namespace Poker.Server
{
    class GameClient : NetConnection
    {
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

                default:
                    throw new Exception("Message " + id + " is not implemented");
            }
            Console.WriteLine("Received '{1}' from {0}", this.Id, content);
        }

        public void handleHelloConnectMessage(HelloConnectMessage message)
        {
            Console.WriteLine("User {0} just joined !", message.username);
        }
    }
}