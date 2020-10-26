using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using TNDDMMainServer.Classes.Token;
using System.Threading;

namespace TNDDMMainServer
{
    class LobbyRoomsManager
    {
        static List<LobbyRoom> rooms = new List<LobbyRoom>();

        static int startPort = 26951;

        static List<PortData> ports = new List<PortData>();

        public static List<LobbyRoom> Rooms
        {
            get
            {
                return rooms;
            }
        }

        public static void CreateRoom(int clientIndex , string roomName)
        {
            foreach (var room in rooms)
            {
                if (room.CheckPlayer(Server.clients[clientIndex].UUID))
                {
                    return;
                }
            }
            if(GetEmptyPort() < 0)
            {
                return;
            }
            string roomUUID = Guid.NewGuid().ToString();

            rooms.Add(new LobbyRoom(roomUUID, clientIndex , GameType.Classic , roomName));
        }

        public static void EnterRoom(int playerIndex , string roomUUID)
        {
            foreach (var room in rooms)
            {
                if(string.Equals(room.UUID , roomUUID) && room.PlayerCount < 2)
                {
                    room.AddPlayer(playerIndex);
                }
            }
        }

        public static void ToggleReady(int playerIndex)
        {
            foreach (var room in rooms)
            {
                if (string.Equals(room.UUID, GetRoom(Server.clients[playerIndex].UUID).UUID))
                {
                    room.ToggleReady(playerIndex);
                }
            }
        }

        public static void ExitRoom(int playerIndex)
        {
            if(Server.clients[playerIndex] != null && GetRoom(Server.clients[playerIndex].UUID) != null)
            {
                foreach (var room in rooms)
                {
                    if (!room.Started && string.Equals(room.UUID, GetRoom(Server.clients[playerIndex].UUID).UUID))
                    {
                        room.RemovePlayer(playerIndex);
                        break;
                    }
                }
            }
        }

        public static void StartGame(int playerIndex)
        {
            int port = GetEmptyPort();
            if (port < 0)
            {
                return;
            }

            foreach (var room in rooms)
            {
                if (room.CheckPlayer(Server.clients[playerIndex].UUID) && room.CanStart())
                {
                    //AddRoomToDatabase(room , port);
                    room.Started = true;

                    foreach (PlayerData player in room.Players)
                    {
                        string token = TokenGenerator.GetNewToken();
                        player.token = token;
                        ServerSend.RoomStarting(player.index);
                    }

                    Process matchServer = new Process();
                    matchServer.StartInfo.UseShellExecute = true;
                    matchServer.StartInfo.FileName = "C:\\Users\\Guray\\Documents\\Projects\\Guray\\TNDDMServerSide\\TNDDMMatchServer\\bin\\Debug\\netcoreapp3.1\\TNDDMMatchServer.exe";
                    matchServer.StartInfo.CreateNoWindow = false;
                    //matchServer.StartInfo.RedirectStandardOutput = true;

                    List<string> args = new List<string>() { 
                        port.ToString() , 
                        room.UUID , 
                        room.Players[0].playerUUID ,
                        room.Players[0].token ,
                        room.Players[0].playerName ,
                        room.Players[1].playerUUID ,
                        room.Players[1].token ,
                        room.Players[1].playerName
                    };

                    foreach (string arg in args)
                    {
                        matchServer.StartInfo.ArgumentList.Add(arg);
                    }
                    
                    matchServer.Start();

                    Thread.Sleep(400);

                    foreach (PlayerData player in room.Players)
                    {
                        ServerSend.RoomStarted(player.index , room, "127.0.0.1" , port , player.token);
                        Server.clients[player.index].tcp.socket.Client.Shutdown(System.Net.Sockets.SocketShutdown.Both);

                    }

                    return;
                }
            }
        }

        public static LobbyRoom GetRoom(string playerUUID)
        {
            foreach (var room in rooms)
            {
                if (room.CheckPlayer(playerUUID))
                {
                    return room;
                }
            }
            return null;
        }

        static int GetEmptyPort()
        {
            GetPorts();

            if (ports.Count == 10)
            {
                return -1;
            }

            else
            {
                for (int i = 1; i < 11; i++)
                {
                    bool isUsed = false;

                    foreach (var port in ports)
                    {
                        if(port.Port == startPort + i)
                        {
                            isUsed = true;
                        }
                    }
                    if (!isUsed)
                    {
                        return startPort + i;
                    }
                }
                return -1;
            }
        }

        public static void CloseRoom(LobbyRoom room)
        {
            if (rooms.Contains(room))
            {
                rooms.Remove(room);
            }
        }

        public static void GetPorts()
        {
            ports = new List<PortData>();

            MySqlConnection mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"SELECT isActive, UUID, IP, Port, PlayerUUIDs FROM match_server.match_servers", mySqlConnection);

            using (MySqlDataReader mySqlDataReader = command.ExecuteReader())
            {
                while (mySqlDataReader.Read())
                {
                    ports.Add(new PortData(mySqlDataReader.GetString("UUID"), mySqlDataReader.GetInt32("Port")));
                }
            }

            mySqlConnection.Close();
        }

        public static void AddRoomToDatabase(LobbyRoom room , int port)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"INSERT INTO match_server.match_servers(isActive,UUID,IP,Port,PlayerUUIDs) VALUES('{0}','{room.UUID}','{""}','{port}','{room.GetPlayerUUIDs()}')", mySqlConnection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Data Inserted");
                }
                else
                {
                    Console.WriteLine("Data Not Inserted");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            mySqlConnection.Close();
        }
    }

    class PortData
    {
        string roomUUID;
        int portNumber;

        public PortData(string uuid , int port)
        {
            roomUUID = uuid;
            portNumber = port;
        }

        public int Port
        {
            get
            {
                return portNumber;
            }
        }

        public bool IsCorrectUUID(string uuid)
        {
            return String.Equals(roomUUID, uuid);
        }
    }
}
