using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.GameScripts.BoardScripts.Pathfinding
{
    public class GridNode
    {
        public int isVisited = 1;
        public int x;
        public int y;
        public bool hasPortal;
        public int portalX;
        public int portalY;
    }
}
