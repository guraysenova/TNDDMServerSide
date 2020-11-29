using System;
using System.Collections.Generic;
using System.Text;
using TNDDMMatchServer.Classes.GameScripts.GameData;

namespace TNDDMMatchServer.Classes
{
    class RequestedCrestData
    {
        public CrestType CrestType { get; }
        public int CrestLevel { get; }
        public int CrestAmount { get; }

        public RequestedCrestData(CrestType crestType , int crestLevel , int crestAmount)
        {
            CrestType = crestType;
            CrestLevel = crestLevel;
            CrestAmount = crestAmount;
        }

        public static List<RequestedCrestData> GetRequestedCrestDatasFromCosts(IEnumerable<Cost> costs)
        {
            List<RequestedCrestData> requestedCrests = new List<RequestedCrestData>();
            foreach (var cost in costs)
            {
                Enum.TryParse(cost.CrestType, out CrestType crestType);
                requestedCrests.Add(new RequestedCrestData(crestType, cost.CrestTier, cost.CrestAmount));
            }
            return requestedCrests;
        }
    }
}
