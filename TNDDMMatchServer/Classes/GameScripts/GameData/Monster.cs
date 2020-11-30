using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.GameScripts.GameData
{
    public class Monster
    {
        [JsonProperty("monsterID")]
        public string MonsterID;

        [JsonProperty("monsterName")]
        public string MonsterName;

        [JsonProperty("monsterType")]
        public string MonsterType;

        [JsonProperty("monsterNature")]
        public string MonsterNature;

        [JsonProperty("stars")]
        public int Stars;

        [JsonProperty("speed")]
        public int Speed;

        [JsonProperty("health")]
        public int Health;

        [JsonProperty("attackPower")]
        public int AttackPower;

        [JsonProperty("defensePower")]
        public int DefensePower;

        [JsonProperty("baseRange")]
        public int BaseRange;  // attack range

        [JsonProperty("freeMovement")]
        public int FreeMovement; // free movements we can make without any crests

        [JsonProperty("moveMultiplier")]
        public int MoveMultiplier; // movement points we get per movement crest

        [JsonProperty("specialAbilities")]
        public List<Ability> SpecialAbilities;

        [JsonProperty("passiveAbilities")]
        public List<Ability> PassiveAbilities;

        [JsonProperty("costs")]
        public List<Cost> Costs;

        [JsonProperty("description")]
        public string Description;
    }
}
