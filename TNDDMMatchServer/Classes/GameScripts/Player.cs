using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.GameScripts
{
    class Player
    {
        DicePool dicePool;

        CrestPool crestPool;

        public Player(PlayerLoginData playerLoginData)
        {
            playerData = playerLoginData;
            dicePool = new DicePool();
            crestPool = new CrestPool();
        }

        public CrestPool Crests
        {
            get
            {
                return crestPool;
            }
            set
            {
                crestPool = value;
            }
        }

        public bool HasCrests(IEnumerable<RequestedCrestData> requestedCrests)
        {
            return crestPool.HasCrests(requestedCrests);
        }

        public DicePool Dices
        {
            get
            {
                return dicePool;
            }
            set
            {
                dicePool = value;
            }
        }

        #region Data

        PlayerLoginData playerData;

        #region Login Data
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
        #endregion


        #endregion
    }
}
