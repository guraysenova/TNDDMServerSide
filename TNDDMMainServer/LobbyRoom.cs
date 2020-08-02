using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMainServer
{
    class LobbyRoom
    {
        string roomUUID;
        List<string> playerUUIDs = new List<string>();
        GameType gameType = new GameType();
        string roomName;


        public LobbyRoom(string roomUUID , string playerUUID , GameType gameType , string roomName)
        {
            this.roomUUID = roomUUID;
            playerUUIDs.Add(playerUUID);
            this.gameType = gameType;
            this.roomName = roomName;
        }

        public bool AddPlayer(string player)
        {
            if(playerUUIDs.Count < 2)
            {
                playerUUIDs.Add(player);
                // TODO: Do something to alert existing players
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemovePlayer(string player)
        {

        }

        public string UUID
        {
            get
            {
                return roomUUID;
            }
        }

        public bool CheckPlayer(string playerUUID)
        {
            bool value = false;
            foreach (var uuid in playerUUIDs)
            {
                if(String.Equals(uuid , playerUUID))
                {
                    value = true;
                }
            }
            return value;
        }

        public bool CanStart()
        {
            return playerUUIDs.Count == 2;
        }

        public string GetPlayerUUIDs()
        {
            string val = "";

            for (int i = 0; i < playerUUIDs.Count; i++)
            {
                if(i == 0)
                {
                    val += playerUUIDs[i];
                }
                else
                {
                    val += ("," + playerUUIDs[i]);
                }
            }

            return val;
        }
        public int PlayerCount
        {
            get
            {
                return playerUUIDs.Count;
            }
        }
        public string RoomName
        {
            get
            {
                return roomName;
            }
        }

        public int GameTypeIndex
        {
            get
            {
                return (int)gameType;
            }
        }
    }

    public enum GameType
    {
        Classic = 0
    }
}
