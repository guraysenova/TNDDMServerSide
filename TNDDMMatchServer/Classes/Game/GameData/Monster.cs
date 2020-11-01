using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.Game.GameData
{
    public class Monster
    {
        [JsonProperty("monsterID")]
        public string MonsterID;

        [JsonProperty("monsterName")]
        public string MonsterName;

        [JsonProperty("monsterType")]
        public string MonsterType;

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

        [JsonProperty("specialAbilities")]
        public List<SpecialAbility> SpecialAbilities;

        [JsonProperty("summonCosts")]
        public List<SummonCost> SummonCosts;
    }
}
