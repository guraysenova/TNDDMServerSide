using System.Collections.Generic;
using TNDDMMatchServer.Classes.GameScripts.BoardScripts;
using TNDDMMatchServer.Classes.GameScripts.GameData;

namespace TNDDMMatchServer.Classes.GameScripts
{
    class Game
    {
        Board board;

        List<Team> teams;

        GameType gameType;

        GameDataReader gameData;

        public Game(List<Team> teams , GameType gameType = GameType.Classic)
        {
            this.teams = teams;
            this.gameType = gameType;
            board = new Board(new TwoDCoordinate(23, 35));
            gameData = new GameDataReader();
        }

        public bool CanMove()
        {
            return false;
        }

        public bool CanAttack()
        {
            return false;
        }

        public bool CanSummon()
        {
            return false;
        }

        public bool CanPlace()
        {
            return false;
        }

        public bool IsTurn()
        {
            return false;
        }
        // Attack , move , turn etc functions
    }
}
