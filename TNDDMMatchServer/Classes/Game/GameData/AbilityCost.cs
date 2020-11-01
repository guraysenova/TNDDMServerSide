using Newtonsoft.Json;

namespace TNDDMMatchServer.Classes.Game.GameData
{
    public class AbilityCost
    {
        [JsonProperty("crestType")]
        public string CrestType;

        [JsonProperty("crestAmount")]
        public int CrestAmount;
    }
}
