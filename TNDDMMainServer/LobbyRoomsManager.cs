using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMainServer
{
    class LobbyRoomsManager
    {
        static List<LobbyRoom> rooms = new List<LobbyRoom>();

        int startPort = 26951;

        static List<PortData> ports = new List<PortData>();

        public static List<LobbyRoom> Rooms
        {
            get
            {
                return rooms;
            }
        }

        public void CreateRoom(string playerUUID)
        {
            foreach (var room in rooms)
            {
                if (room.CheckPlayer(playerUUID))
                {
                    return;
                }
            }
            if(GetEmptyPort() < 0)
            {
                return;
            }
            string roomUUID = Guid.NewGuid().ToString();

            rooms.Add(new LobbyRoom(roomUUID, playerUUID , GameType.Classic));
        }

        public void CloseRoom(string playerUUID)
        {
            foreach (var room in rooms)
            {
                if (room.CheckPlayer(playerUUID))
                {
                    // TODO: CLOSE HERE
                }
            }
        }

        public void StartGame(string playerUUID)
        {
            int port = GetEmptyPort();
            if (port < 0)
            {
                return;
            }

            string roomUUID = "";

            bool canStart = false;

            foreach (var room in rooms)
            {
                if (room.CheckPlayer(playerUUID))
                {
                    roomUUID = room.UUID;
                    canStart = true;
                }
            }

            if (canStart)
            {
                ports.Add(new PortData(roomUUID, port));
            }
        }

        int GetEmptyPort()
        {
            if(ports.Count == 10)
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

        public void GetPorts()
        {

        }

        public void AddRoomToDatabase(LobbyRoom room , int port)
        {

        }
    }

    class PortData
    {
        string roomUUID;
        int portNumber;

        public PortData(string uuid , int port)
        {
            roomUUID = uuid;
            port = portNumber;
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
