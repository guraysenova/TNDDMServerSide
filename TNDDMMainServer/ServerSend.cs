using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TNDDMMainServer
{
    class ServerSend
    {
        private static void SendTCPData(int toClient , Packet packet)
        {
            packet.WriteLength();
            Server.clients[toClient].tcp.SendData(packet);
        }

        private static void SendTCPDataToAll(int exceptClient , Packet packet)
        {
            packet.WriteLength();
            for (int i = 0; i < Server.MaxPlayers; i++)
            {
                if(i != exceptClient)
                {
                    Server.clients[i].tcp.SendData(packet);
                }
            }
        }

        public static void TokenRequest(int toClient , string message)
        {
            using(Packet packet = new Packet((int)ServerPackets.TokenRequest))
            {
                packet.Write(message);
                packet.Write(toClient);

                SendTCPData(toClient, packet);
            }
        }
    }
}
