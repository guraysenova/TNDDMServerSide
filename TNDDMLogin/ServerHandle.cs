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
            username = username.Remove(username.Length - 1);

            Console.WriteLine($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {fromClient}.");
            if(fromClient != clientIdCheck)
            {
                Console.WriteLine($"Player \"{username}\" (ID: {fromClient}) has assumed the wrong client ID");
            }

            string token = TokenGenerator.GetNewToken();

            string userUUID = Guid.NewGuid().ToString();

            TokenManager.AddToken(userUUID, token);

            ServerSend.Token(fromClient , token, "127.0.0.1", 26951 , userUUID);
        }
    }
}
