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

        [JsonProperty("costs")]
        public List<Cost> Costs;

        [JsonProperty("description")]
        public string Description;
    }
}
