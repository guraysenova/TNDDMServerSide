using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;
using TNDDMMainServer.Classes.Token;

namespace TNDDMMainServer
{
    class LobbyRoom
    {
        string roomUUID;
        List<PlayerData> players = new List<PlayerData>();
        GameType gameType = new GameType();
        string roomName;
        bool started = false;


        public LobbyRoom(string roomUUID , int playerIndex , GameType gameType , string roomName)
        {
            this.roomUUID = roomUUID;

            players.Add(new PlayerData(false ,Server.clients[playerIndex].UUID , Server.clients[playerIndex].ClientName , playerIndex));

            this.gameType = gameType;
            this.roomName = roomName;
        }

        public void AddPlayer(int playerIndex)
        {
            if(players.Count < 2)
            {
                players.Add(new PlayerData(false, Server.clients[playerIndex].UUID, Server.clients[playerIndex].ClientName, playerIndex));
                UpdatePlayers();
            }
        }

        void UpdatePlayers()
        {
            foreach (var player in players)
            {
                ServerSend.RoomData(player.index, this);
            }
        }

        public void RemovePlayer(int playerIndex)
        {
            foreach (var player in players)
            {
                if(player.index == playerIndex)
                {
                    players.Remove(player);
                    if(players.Count > 0) 
                    {
                        UpdatePlayers();
                    }
                    else
                    {
                        LobbyRoomsManager.CloseRoom(this);
                    }
                    break;
                }
            }
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
            foreach (var player in players)
            {
                if(String.Equals(player.playerUUID , playerUUID))
                {
                    value = true;
                }
            }
            return value;
        }

        public void ToggleReady(int clientIndex)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if(players[i].index == clientIndex)
                {
                    players[i].isReady = !players[i].isReady;
                }
            }
            UpdatePlayers();
        }

        public bool CanStart()
        {
            return (players.Count == 2 && players[0].isReady && players[1].isReady && !started);
        }

        public bool Started
        {
            set
            {
                started = value;
            }
        }

        public string GetPlayerUUIDs()
        {
            string val = "";

            for (int i = 0; i < players.Count; i++)
            {
                if(i == 0)
                {
                    val += players[i].playerUUID;
                }
                else
                {
                    val += ("," + players[i].playerUUID);
                }
            }

            return val;
        }
        public int PlayerCount
        {
            get
            {
                return players.Count;
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
        public List<PlayerData> Players
        {
            get
            {
                return players;
            }
        } 
    }
}

[System.Serializable]
class PlayerData
{
    public bool isReady;
    public string playerUUID;
    public string playerName;
    public int index;
    public string token;

    public PlayerData(bool ready , string uuid , string playerNameVal , int indexVal)
    {
        isReady = ready;
        playerUUID = uuid;
        playerName = playerNameVal;
        index = indexVal;
        token = "";
    }
}
