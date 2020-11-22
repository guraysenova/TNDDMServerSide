using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.GameScripts.TurnScripts
{
    class Turn
    {
        List<Team> teams;

        int turnCount;

        int playerCount;

        public TurnData TurnData { get; }

        public Turn(List<Team> teams)
        {
            turnCount = 0;
            this.teams = teams;
            TurnData = new TurnData();

            foreach (var team in teams)
            {
                playerCount += team.Players.Count;
            }
        }

        public void AdvancePhase()
        {
            if(TurnData.Phase == TurnPhase.Battle)
            {
                turnCount++;
                TurnData.TeamIndex = (TurnData.TeamIndex + 1) % teams.Count;
                TurnData.Phase = TurnPhase.Roll;
                TurnData.PlayerIndexInTeam = (turnCount % playerCount) / teams.Count;
            }
        }
    }
}
