using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.Game.Board.UnfoldingDice
{
    [System.Serializable]
    public class DiceUnfoldData
    {
        [JsonProperty("myCoordinates")]
        public List<TwoDCoordinate> myCoordinates;
    }
}
