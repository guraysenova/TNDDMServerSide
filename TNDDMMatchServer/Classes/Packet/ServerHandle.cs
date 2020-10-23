using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer
{
    class ServerHandle
    {
        public static void MatchToken(int fromClient , Packet packet)
        {
            string token = packet.ReadString();
            int clientIdCheck = packet.ReadInt();
            string clientGivenRoomUUID = packet.ReadString();
            string clientUUID = packet.ReadString();

            Console.WriteLine($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {fromClient}.");
            if (fromClient != clientIdCheck)
            {
                Console.WriteLine($"Player (ID: {fromClient}) has assumed the wrong client ID");
            }

            if (TokenManager.IsTokenValid(clientGivenRoomUUID, clientUUID, token))
            {
                Console.WriteLine("User : " + Server.clients[fromClient].clientName + " connected with the correct token");
            }
            else
            {
                Server.clients[fromClient].tcp.Disconnect();
                Console.WriteLine("User connected with the incorrect token");
            }
        }
    }
}
