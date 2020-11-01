using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.Game.GameData
{
    public class SpecialAbility
    {
        [JsonProperty("abilityID")]
        public string AbilityID;

        [JsonProperty("abilityName")]
        public string AbilityName;

        [JsonProperty("abilityType")]
        public string AbilityType;

        [JsonProperty("abilityUseType")]
        public string AbilityUseType;

        [JsonProperty("abilityCosts")]
        public List<AbilityCost> AbilityCosts;
    }
}
