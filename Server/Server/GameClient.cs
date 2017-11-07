using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IO;
using Core.Protocol;
using Ether.Network;
using Ether.Network.Packets;

namespace Server.Server
{
    class GameClient : NetConnection
    {

        public void SendFirstPacket()
        {
            using (var packet = new NetPacket())
            {
                packet.Write("Welcome " + this.Id.ToString());

                this.Send(packet);
            }
        }

        public override void HandleMessage(NetPacketBase packet)
        {
            int id = packet.Read<int>();
            string content = packet.Read<string>();
            ProtocolMessage message;
            switch (id)
            {
                case HelloConnectMessage.ID:
                    message = RawObjectReader.Load<HelloConnectMessage>(content);
                    break;

                default:
                    throw new Exception("Message {0} is not implemented");
            }


            Console.WriteLine("Received '{1}' from {0}", this.Id, content);
        }

    }
}