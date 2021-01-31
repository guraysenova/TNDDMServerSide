using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.GameScripts
{
    class Team
    {
        List<Player> players = new List<Player>();

        TeamEnum teamEnum;

        public Team(List<Player> players , TeamEnum team)
        {
            this.players = players;
            this.teamEnum = team;
        }

        public Team(Player player, TeamEnum team)
        {
            this.players = new List<Player>() { player };
            this.teamEnum = team;
        }

        public List<Player> Players
        {
            get
            {
                return players;
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
