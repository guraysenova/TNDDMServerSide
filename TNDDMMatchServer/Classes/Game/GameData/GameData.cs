using Newtonsoft.Json;
using System.Collections.Generic;

namespace TNDDMMatchServer.Classes.Game.GameData
{
    public class GameData
    {
        [JsonProperty("monsters")]
        public List<Monster> Monsters;

        [JsonProperty("abilities")]
        public List<Ability> Abilities;

        [JsonProperty("spells")]
        public List<Spell> Spells;

        [JsonProperty("traps")]
        public List<Trap> Traps;
    }
}
