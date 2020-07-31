using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMainServer
{
    class LobbyRoomsManager
    {
        static List<LobbyRoom> rooms = new List<LobbyRoom>();
        void CreateRoom(string playerUUID)
        {
            // check rooms if this uuid has room
        }
    }

    class PortData
    {
        public string UUID;
        public int port;
    }
}
