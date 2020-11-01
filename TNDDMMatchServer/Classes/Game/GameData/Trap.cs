using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.Game.GameData
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

        [JsonProperty("summonCosts")]
        public List<SummonCost> SummonCosts;
    }
}
