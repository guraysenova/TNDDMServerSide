using Newtonsoft.Json;

namespace TNDDMMatchServer.Classes.Game.GameData
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
