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

        public LobbyRoom(string roomUUID , string playerUUID , GameType gameType)
        {
            this.roomUUID = roomUUID;
            playerUUIDs.Add(playerUUID);
            this.gameType = gameType;
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
    }

    public enum GameType
    {
        Classic
    }
}
