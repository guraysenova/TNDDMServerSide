using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes
{
    class Crest
    {
        CrestType crestType;

        int crestLevel;

        public Crest(CrestType crestType , int crestLevel = 1)
        {
            this.crestType = crestType;
            this.crestLevel = crestLevel;
        }

        public CrestType CrestType
        {
            get
            {
                return crestType;
            }
        }

        public int CrestLevel
        {
            get
            {
                return crestLevel;
            }
        }
    }
}
