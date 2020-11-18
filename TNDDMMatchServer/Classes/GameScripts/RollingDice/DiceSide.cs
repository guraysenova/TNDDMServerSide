using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes
{
    class DiceSide
    {
        Crest crest;
        int amount = 0;

        public DiceSide(Crest crest, int amount = 1)
        {
            this.crest = crest;
            this.amount = amount;
        }

        public Crest Crest
        {
            get
            {
                return crest;
            }
        }

        public bool IsCrest(CrestType crestType, int crestLevel)
        {
            return crest.CrestType == crestType && crest.CrestLevel == crest.CrestLevel;
        }

        public int Amount
        {
            get
            {
                return amount;
            }
        }
    }
}
