using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMainServer
{
    class ServerHandle
    {
        public static void TokenReceived(int fromClient, Packet packet)
        {
            int clientIdCheck = packet.ReadInt();
            string username = packet.ReadString();
            string token = packet.ReadString();

            Console.WriteLine($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {fromClient}.");
            if (fromClient != clientIdCheck)
            {
                Console.WriteLine($"Player \"{username}\" (ID: {fromClient}) has assumed the wrong client ID");
            }

            if (TokenManager.IsTokenValid(username, token))
            {
                Console.WriteLine("User : " + username + " connected with the correct token");
                ServerSend.ConnectedToLobby(fromClient);
            }
            else
            {
                Server.clients[fromClient].tcp.Disconnect();
                Console.WriteLine("User : " + username + " connected with the incorrect token");
            }
        }

        public static void LobbyRoomRequest(int fromClient , Packet packet)
        {
            foreach (var room in LobbyRoomsManager.Rooms)
            {
                ServerSend.LobbyRoom(fromClient, room);
            }
        }

        public static void CreateRoom(int fromClient , Packet packet)
        {
            string UUID = packet.ReadString();
            string roomName = packet.ReadString();
            LobbyRoomsManager.CreateRoom(UUID,roomName);
        }

    }
}
