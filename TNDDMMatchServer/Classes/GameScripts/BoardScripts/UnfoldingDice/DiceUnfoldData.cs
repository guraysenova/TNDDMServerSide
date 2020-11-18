using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.GameScripts.BoardScripts.UnfoldingDice
{
    [System.Serializable]
    public class DiceUnfoldData
    {
        [JsonProperty("myCoordinates")]
        public List<TwoDCoordinate> myCoordinates;
    }
}
