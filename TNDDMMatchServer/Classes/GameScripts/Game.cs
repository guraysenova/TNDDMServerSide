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
            int pointMultiplier = board.GetAgent(agentIndex).MonsterData.MoveMultiplier;

            int movementPoints = 0;
            movementPoints += board.GetAgent(agentIndex).MonsterData.FreeMovement;
            movementPoints += (GetPlayer(playerUUID).Crests.MovementCrests.Amount * pointMultiplier);

            int pathLength = board.GetPathDistance(agentIndex, targetTileIndex);
         
            if(pathLength == 0 || pathLength > movementPoints)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CanAttack(string playerUUID , int agentIndex , int targetAgentIndex , int attackIndex)
        {
            if(IsTurnAndPhase(playerUUID , TurnPhase.Battle))
            {
                if(board.GetAgent(agentIndex).MonsterData != null && 
                   board.GetAgent(targetAgentIndex).MonsterData != null && 
                   GetPlayer(playerUUID).HasCrests(RequestedCrestData.GetRequestedCrestDatasFromCosts(board.GetAgent(agentIndex).MonsterData.SpecialAbilities[attackIndex].Costs)))
                {
                    float distance = TwoDCoordinate.FlyDistance(board.GetAgent(agentIndex).TileData.coordinates, board.GetAgent(targetAgentIndex).TileData.coordinates);
                    if(distance <= board.GetAgent(agentIndex).MonsterData.SpecialAbilities[attackIndex].Range)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanSummon(string playerUUID , string monsterID)
        {
            if (GetPlayer(playerUUID).HasCrests(RequestedCrestData.GetRequestedCrestDatasFromCosts(gameData.GetMonster(monsterID).Costs)))
            {
                return true;
            }
            return false;
        }

        public bool CanPlace(string playerUUID , int targetTileIndex , int diceUnfoldDataIndex , bool isMirrored , int rotation)
        {
            return board.CanPlace(GetPlayer(playerUUID).TeamEnum, targetTileIndex, diceUnfoldDataIndex, isMirrored, rotation);
        }

        public bool IsTurnAndPhase(string playerUUID , TurnPhase phase)
        {
            return turnManager.IsPlayersTurnAndPhase(playerUUID, phase);
        }

        Player GetPlayer(string playerUUID)
        {
            foreach (Team team in teams)
            {
                foreach (Player player in team.Players)
                {
                    if(string.Equals(player.UUID , playerUUID))
                    {
                        return player;
                    }
                }
            }

            return null;
        }
    }
}
