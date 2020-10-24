using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes
{
    class MatchData
    {
        string matchUUID;

        public MatchData(string matchUUID)
        {
            this.matchUUID = matchUUID;
        }

        public string MatchUUID
        {
            get
            {
                return matchUUID;
            }
        }
    }
}
