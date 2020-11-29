using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.GameScripts.GameData
{
    public class Ability
    {
        [JsonProperty("abilityID")]
        public string AbilityID;

        [JsonProperty("abilityName")]
        public string AbilityName;

        [JsonProperty("abilityType")]
        public string AbilityType;

        [JsonProperty("abilityUseType")]
        public string AbilityUseType;

        [JsonProperty("range")]
        public int Range;

        [JsonProperty("costs")]
        public List<Cost> Costs;

        [JsonProperty("description")]
        public string Description;
    }
}
