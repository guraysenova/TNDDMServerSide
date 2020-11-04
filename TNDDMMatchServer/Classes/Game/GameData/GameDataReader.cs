using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TNDDMMatchServer.Classes.Game.GameData
{
    class GameDataReader
    {
        GameData gameData = new GameData();

        public GameDataReader()
        {
            string json = File.ReadAllText(@"C:\Users\Guray\Documents\Projects\Guray\TNDDMServerSide\TNDDMMatchServer\Classes\Game\GameData\DataSamples.json");
            gameData = JsonConvert.DeserializeObject<GameData>(json);
        }

        public GameData GameData
        {
            get
            {
                return gameData;
            }
        }
    }
}
