using System.Collections.Generic;
using Newtonsoft.Json;

namespace TNDDMMatchServer.Classes.GameScripts.GameData
{
    public class Spell
    {
        [JsonProperty("spellID")]
        public string SpellID;

        [JsonProperty("spellName")]
        public string SpellName;

        [JsonProperty("spellType")]
        public string SpellType;

        [JsonProperty("spellUseType")]
        public string SpellUseType;

        [JsonProperty("spellForce")]
        public int SpellForce;

        [JsonProperty("spellUseAmount")]
        public int SpellUseAmount;

        [JsonProperty("summonCosts")]
        public List<SummonCost> SummonCosts;

        [JsonProperty("description")]
        public string Description;
    }
}
