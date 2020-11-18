using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TNDDMMatchServer.Classes.GameScripts.BoardScripts.UnfoldingDice
{
    [Serializable]
    class DiceUnfoldDatas
    {
        [JsonProperty("DiceUnfoldData")]
        public List<DiceUnfoldData> DiceUnfoldData;
        [JsonProperty("MirroredDiceUnfoldData")]
        public List<DiceUnfoldData> MirroredDiceUnfoldData;
    }
}
