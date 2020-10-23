using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TNDDMMatchServer
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

        public static void MatchTokenRequest(int toClient , string message)
        {
            using(Packet packet = new Packet((int)ServerPackets.MatchTokenRequest))
            {
                packet.Write(message);
                packet.Write(toClient);

                SendTCPData(toClient, packet);
            }
        }

        public static void MatchStarted(int toClient , int clientOrder)
        {
            using (Packet packet = new Packet((int)ServerPackets.MatchStarted))
            {
                packet.Write(clientOrder);
                SendTCPData(toClient, packet);
            }
        }
    }
}
