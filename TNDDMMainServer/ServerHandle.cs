using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNDDMMainServer
{
    class ServerHandle
    {
        public static void TokenReceived(int fromClient, Packet packet)
        {
            int clientIdCheck = packet.ReadInt();
            string username = packet.ReadString();
            username = username.Remove(username.Length - 1);

            string tokenUUID = packet.ReadString();
            string token = packet.ReadString();
            Server.clients[fromClient].ClientName = username;
            Console.WriteLine($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {fromClient}.");
            if (fromClient != clientIdCheck)
            {
                Console.WriteLine($"Player \"{username}\" (ID: {fromClient}) has assumed the wrong client ID");
            }

            if (TokenManager.IsTokenValid(tokenUUID, token))
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

        public static void CreateRoom(int fromClient, Packet packet)
        {
            string UUID = packet.ReadString();
            if (string.Equals(Server.clients[fromClient].UUID , UUID))
            {
                string roomName = packet.ReadString();
                if (roomName.Length > 1)
                {
                    roomName = roomName.Remove(roomName.Length - 1);
                    LobbyRoomsManager.CreateRoom(fromClient, roomName);
                    LobbyRoom room = LobbyRoomsManager.GetRoom(Server.clients[fromClient].UUID);
                    if(room != null)
                    {
                        ServerSend.RoomData(fromClient, room);
                    }
                }
            }
        }

        public static void LoginRoom(int fromClient , Packet packet)
        {
            string roomUUID = packet.ReadString();
            LobbyRoomsManager.EnterRoom(fromClient, roomUUID);
        }

        public static void ToggleReady(int fromClient, Packet packet)
        {
            LobbyRoomsManager.ToggleReady(fromClient);
        }
    }
}
