using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.GameScripts
{
    class Team
    {
        List<Player> players = new List<Player>();

        TeamEnum teamEnum;

        public Team(List<Player> players , TeamEnum team)
        {
            this.players = players;
        }

        public Team(Player player, TeamEnum team)
        {
            this.players = new List<Player>() { player };
        }

        public List<Player> Players
        {
            get
            {
                return players;
            }
        }
    }
}
