using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMainServer
{
    class Lobby
    {
        string uuid;
        List<string> players = new List<string>();
        GameType gameType = new GameType();

        public Lobby(string UUID , string player , GameType gameType)
        {
            uuid = UUID;
            players.Add(player);
            this.gameType = gameType;
        }

        public bool AddPlayer(string player)
        {
            if(players.Count < 2)
            {
                players.Add(player);
                // TODO: Do something to alert existing players
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemovePlayer(string player)
        {

        }
    }

    public enum GameType
    {
        Classic
    }
}
