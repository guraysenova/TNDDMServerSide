using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.Game
{
    class Player
    {
        PlayerLoginData playerLoginData;
        public Player(PlayerLoginData playerLoginData)
        {
            this.playerLoginData = playerLoginData;
        }

        public PlayerLoginData PlayerLoginData
        {
            get
            {
                return playerLoginData;
            }
        }
    }
}
