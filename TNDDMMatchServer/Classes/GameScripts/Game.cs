using System.Collections.Generic;
using TNDDMMatchServer.Classes.GameScripts.BoardScripts;

namespace TNDDMMatchServer.Classes.GameScripts
{
    class Game
    {
        public Board Board { get; }
        List<Team> teams;
        GameType gameType;
        public Game(List<Team> teams , GameType gameType = GameType.Classic)
        {
            this.teams = teams;
            this.gameType = gameType;
            Board = new Board(new TwoDCoordinate(23, 35));
        }
    }
}
