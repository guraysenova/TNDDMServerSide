using System.Collections.Generic;
using TNDDMMatchServer.Classes.GameScripts.BoardScripts;
using TNDDMMatchServer.Classes.GameScripts.GameData;
using TNDDMMatchServer.Classes.GameScripts.TurnScripts;

namespace TNDDMMatchServer.Classes.GameScripts
{
    class Game
    {
        Board board;

        List<Team> teams;

        GameType gameType;

        GameDataReader gameData;

        TurnManager turnManager; 

        public Game(List<Team> teams , GameType gameType = GameType.Classic)
        {
            this.teams = teams;
            this.gameType = gameType;
            board = new Board(new TwoDCoordinate(23, 35));
            gameData = new GameDataReader();
            turnManager = new TurnManager(this.teams);
        }

        public bool CanMove(string playerUUID , int agentIndex , int targetTileIndex) // agent id , target tile etc
        {
            return false;
        }

        public bool CanAttack(string playerUUID , int agentIndex , int targetAgentIndex)
        {
            return false;
        }

        public bool CanSummon(string playerUUID , string monsterID)
        {
            return false;
        }

        public bool CanPlace(string playerUUID , int targetTileIndex , int diceUnfoldDataIndex)
        {
            return false;
        }

        public bool IsTurnAndPhase(string playerUUID , TurnPhase phase)
        {
            return false;
        }
        // Attack , move , turn etc functions
    }
}
