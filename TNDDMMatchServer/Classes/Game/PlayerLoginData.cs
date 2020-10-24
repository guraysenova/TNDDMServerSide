using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.Game
{
    class PlayerLoginData
    {
        string playerUUID;
        string playerToken;
        string playerName;
        PlayerEnum playerEnum;
        TeamEnum teamEnum;

        public PlayerLoginData(string playerUUID, string playerToken, string playerName , PlayerEnum playerEnum , TeamEnum teamEnum)
        {
            this.playerUUID = playerUUID;
            this.playerToken = playerToken;
            this.playerName = playerName;
            this.playerEnum = playerEnum;
            this.teamEnum = teamEnum;
        }

        public string UUID
        {
            get
            {
                return playerUUID;
            }
        }
        public string Token
        {
            get
            {
                return playerToken;
            }
        }

        public string Name
        {
            get
            {
                return playerName;
            }
        }

        public PlayerEnum PlayerEnum
        {
            get
            {
                return playerEnum;
            }
        }

        public TeamEnum TeamEnum
        {
            get
            {
                return teamEnum;
            }
        }
    }
}
