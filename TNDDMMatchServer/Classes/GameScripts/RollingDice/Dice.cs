using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes
{
    class Dice
    {
        List<DiceSide> diceSides;

        bool isUsed;

        public Dice(List<DiceSide> diceSides)
        {
            this.diceSides = new List<DiceSide>(diceSides);
            isUsed = false;
        }

        public bool IsUsed
        {
            get
            {
                return isUsed;
            }
            set
            {
                isUsed = value;
            }
        }

        public DiceSide Roll()
        {
            Random random = new Random();
            return diceSides[random.Next(0, diceSides.Count)];
        }
    }
}
