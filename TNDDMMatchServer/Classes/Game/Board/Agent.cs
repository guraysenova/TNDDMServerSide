using System;
using System.Collections.Generic;
using System.Text;
using TNDDMMatchServer.Classes.Game.GameData;

namespace TNDDMMatchServer.Classes.Game.Board
{
    class Agent
    {
        public int ID { get; set; }
        public PlayerEnum Player { get; set; }

        public TileData TileData { get; set; }

        public AgentType AgentType { get; set; }


    }
}
