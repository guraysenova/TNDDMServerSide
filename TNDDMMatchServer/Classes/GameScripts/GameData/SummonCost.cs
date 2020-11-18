using Newtonsoft.Json;

namespace TNDDMMatchServer.Classes.GameScripts.GameData
{
    public class SummonCost
    {
        [JsonProperty("crestType")]
        public string CrestType;

        [JsonProperty("crestTier")]
        public int CrestTier;

        [JsonProperty("crestAmount")]
        public int CrestAmount;
    }
}
