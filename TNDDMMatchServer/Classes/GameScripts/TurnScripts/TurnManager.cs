using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.GameScripts.TurnScripts
{
    class TurnManager
    {
        List<Team> teams;

        int turnCount;

        int playerCount;

        public Turn Turn { get; }

        public TurnManager(List<Team> teams)
        {
            turnCount = 0;
            this.teams = teams;
            Turn = new Turn();

            foreach (var team in teams)
            {
                playerCount += team.Players.Count;
            }
        }

        bool IsPlayersTurn(string playerUUID)
        {
            int teamIndex = 0;
            int playerIndex = 0;

            bool playerFound = false;
            
            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = 0; j < teams[i].Players.Count; j++)
                {
                    if(string.Equals(teams[i].Players[j].UUID , playerUUID))
                    {
                        teamIndex = i;
                        playerIndex = j;
                        playerFound = true;
                    }
                }
                if (playerFound)
                {
                    break;
                }
            }
            if (!playerFound)
            {
                Console.WriteLine("Player Not Found with given UUID : " + playerUUID);
                return false;
            }

            if(Turn.PlayerIndexInTeam == playerIndex && Turn.TeamIndex == teamIndex)
            {
                return true;
            }

            return false;
        }

        bool IsPhase(TurnPhase phase)
        {
            if(Turn.Phase == phase)
            {
                return true;
            }
            return false;
        }

        public bool IsPlayersTurnAndPhase(string playerUUID , TurnPhase phase)
        {
            return IsPlayersTurn(playerUUID) && IsPhase(phase);
        }

        public void AdvancePhase()
        {
            if(Turn.Phase == TurnPhase.Battle)
            {
                turnCount++;
                Turn.TeamIndex = (Turn.TeamIndex + 1) % teams.Count;
                Turn.Phase = TurnPhase.Roll;
                Turn.PlayerIndexInTeam = (turnCount % playerCount) / teams.Count;
            }
            else
            {
                Turn.Phase = (TurnPhase)((int)Turn.Phase + 1);
            }
        }
    }
}
