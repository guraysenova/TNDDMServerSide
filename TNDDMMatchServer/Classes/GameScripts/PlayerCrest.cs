using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes
{
    [System.Serializable]
    class PlayerCrest
    {
        Crest crest;
        int amount = 0;

        public PlayerCrest(Crest crest , int amount = 0)
        {
            this.crest = crest;
            this.amount = amount;
        }

        public bool IsCrest(CrestType crestType , int crestLevel = 1)
        {
            return crest.CrestType == crestType && crest.CrestLevel == crest.CrestLevel;
        }

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
    }
}
