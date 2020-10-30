using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.Game
{
    class Player
    {
        PlayerLoginData playerData;

        TurnEnum turn;

        public Player(PlayerLoginData playerLoginData)
        {
            turn = TurnEnum.None;
            playerData = playerLoginData;
        }

        public string UUID
        {
            get
            {
                return playerData.UUID;
            }
        }
        public string Token
        {
            get
            {
                return playerData.Token;
            }
        }

        public string Name
        {
            get
            {
                return playerData.Name;
            }
        }

        public PlayerEnum PlayerEnum
        {
            get
            {
                return playerData.PlayerEnum;
            }
        }

        public TeamEnum TeamEnum
        {
            get
            {
                return playerData.TeamEnum;
            }
        }

        public TurnEnum Turn
        {
            get
            {
                return turn;
            }
            set
            {
                turn = value;
            }
        }
    }
}
