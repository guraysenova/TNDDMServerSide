using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMLogin
{
    class ServerHandle
    {
        public static void WelcomeReceived(int fromClient , Packet packet)
        {
            int clientIdCheck = packet.ReadInt();
            string username = packet.ReadString();

            Console.WriteLine($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {fromClient}.");
            if(fromClient != clientIdCheck)
            {
                Console.WriteLine($"Player \"{username}\" (ID: {fromClient}) has assumed the wrong client ID");
            }

            // TODO: send player into game?
        }
    }
}
