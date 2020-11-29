using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.GameScripts.GameData
{
    public class Trap
    {
        [JsonProperty("trapID")]
        public string TrapID;

        [JsonProperty("trapName")]
        public string TrapName;

        [JsonProperty("trapType")]
        public string TrapType;

        [JsonProperty("trapUseType")]
        public string TrapUseType;

        [JsonProperty("health")]
        public int Health;

        [JsonProperty("attackPower")]
        public int AttackPower;

        [JsonProperty("defensePower")]
        public int DefensePower;

        [JsonProperty("costs")]
        public List<Cost> Costs;

        [JsonProperty("description")]
        public string Description;
    }
}
