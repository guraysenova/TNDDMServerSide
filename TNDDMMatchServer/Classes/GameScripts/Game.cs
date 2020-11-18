using System.Collections.Generic;
using TNDDMMatchServer.Classes.GameScripts.BoardScripts;

namespace TNDDMMatchServer.Classes.GameScripts
{
    class Game
    {
        Board board;

        List<Team> teams;

        GameType gameType;

        public Game(List<Team> teams , GameType gameType = GameType.Classic)
        {
            this.teams = teams;
            this.gameType = gameType;
            board = new Board(new TwoDCoordinate(23, 35));
        }

        // Attack , move , turn etc functions
    }
}
