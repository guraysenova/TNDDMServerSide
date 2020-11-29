using System;
using Newtonsoft.Json;

namespace TNDDMMatchServer.Classes.GameScripts.BoardScripts
{
    [Serializable]
    public class TwoDCoordinate
    {
        public TwoDCoordinate(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        [JsonProperty("x")]
        public int x;
        [JsonProperty("y")]
        public int y;

        public static int Distance(TwoDCoordinate first, TwoDCoordinate second)
        {
            int xDiff = first.x - second.x;
            int yDiff = first.y - second.y;

            if (xDiff < 0)
            {
                xDiff *= -1;
            }

            if (yDiff < 0)
            {
                yDiff *= -1;
            }

            return xDiff + yDiff;
        }

        public static float FlyDistance(TwoDCoordinate first, TwoDCoordinate second)
        {
            int xDiff = first.x - second.x;
            int yDiff = first.y - second.y;

            if (xDiff < 0)
            {
                xDiff *= -1;
            }

            if (yDiff < 0)
            {
                yDiff *= -1;
            }

            if(yDiff == 0)
            {
                return xDiff;
            }
            if(xDiff == 0)
            {
                return yDiff;
            }

            return MathF.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
        }
    }
}
