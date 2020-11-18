using Newtonsoft.Json;
using System;
using System.IO;

namespace TNDDMMatchServer.Classes.GameScripts.BoardScripts.UnfoldingDice
{
    class DiceUnfoldDataManager
    {
        DiceUnfoldDatas diceUnfoldingDatas = new DiceUnfoldDatas();

        public DiceUnfoldDataManager()
        {
            string json = File.ReadAllText(@"C:\Users\Guray\Documents\Projects\Guray\TNDDMServerSide\TNDDMMatchServer\Classes\Game\Board\UnfoldingDice\DiceUnfoldDatas.json");
            diceUnfoldingDatas = JsonConvert.DeserializeObject<DiceUnfoldDatas>(json);
        }

        public DiceUnfoldData GetDiceUnfoldData(int index , bool isMirrored)
        {
            if(!isMirrored && diceUnfoldingDatas.DiceUnfoldData.Count <= index)
            {
                Console.WriteLine("DiceUnfoldData at given index does not exist : " + index);
                return null;
            }
            else if (isMirrored && diceUnfoldingDatas.MirroredDiceUnfoldData.Count <= index)
            {
                Console.WriteLine("MirroredDiceUnfoldData at given index does not exist : " + index);
                return null;
            }
            if (isMirrored)
            {
                return diceUnfoldingDatas.MirroredDiceUnfoldData[index];
            }
            else
            {
                return diceUnfoldingDatas.DiceUnfoldData[index];
            }
        }
    }
}
