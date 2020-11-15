using System;
using System.Collections.Generic;
using System.Text;
using TNDDMMatchServer.Classes.Game.GameData;

namespace TNDDMMatchServer.Classes.Game.Board
{
    public class Agent
    {
        public Agent(AgentType agentType , int id ,PlayerEnum playerEnum , TileData tileData , Monster monsterData = null , Spell spellData = null , Trap trapData = null )
        {
            Player = playerEnum;
            ID = id;
            AgentType = agentType;
            TileData = tileData;
            MonsterData = monsterData;
            SpellData = spellData;
            TrapData = trapData;
        }

        public int ID { get;}
        public PlayerEnum Player { get; }

        public TileData TileData { get; set; }

        public AgentType AgentType { get; }

        public Monster MonsterData { get; set; }

        public Spell SpellData { get; set; }

        public Trap TrapData { get; set; }
    }
}
