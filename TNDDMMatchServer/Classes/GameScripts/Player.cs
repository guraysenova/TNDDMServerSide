using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.GameScripts
{
    class Player
    {
        TurnEnum turn;

        DicePool dicePool;

        CrestPool crestPool;

        public Player(PlayerLoginData playerLoginData)
        {
            turn = TurnEnum.None;
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
        #region Turn Data

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

        public bool CanRoll
        {
            get
            {
                return turn == TurnEnum.Roll;
            }
        }

        public bool CanPlay
        {
            get
            {
                return turn == TurnEnum.Play;
            }
        }

        public bool IsTurn
        {
            get
            {
                return turn != TurnEnum.None || turn != TurnEnum.Finished;
            }
        }
        #endregion

        #endregion
    }
}
