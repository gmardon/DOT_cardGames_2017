using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IO;
using Core.Protocol;
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
                    break;

                default:
                    throw new Exception("Message {0} is not implemented", id);
            }
            Console.WriteLine("Received '{1}' from {0}", this.Id, content);
        }

    }
}