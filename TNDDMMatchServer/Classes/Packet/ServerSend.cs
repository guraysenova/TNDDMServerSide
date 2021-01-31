using System.Collections.Generic;

namespace TNDDMMatchServer
{
    class ServerSend
    {
        private static void SendTCPData(int toClient , Packet packet)
        {
            packet.WriteLength();
            Server.clients[toClient].tcp.SendData(packet);
        }

        private static void SendTCPDataToAll(int exceptClient , Packet packet)
        {
            packet.WriteLength();
            for (int i = 0; i < Server.MaxPlayers; i++)
            {
                if(i != exceptClient)
                {
                    Server.clients[i].tcp.SendData(packet);
                }
            }
        }

        public static void MatchTokenRequest(int toClient , string message)
        {
            using(Packet packet = new Packet((int)ServerPackets.MatchTokenRequest))
            {
                packet.Write(message);
                packet.Write(toClient);

                SendTCPData(toClient, packet);
            }
        }

        public static void MatchStarted(int toClient ,int teamEnum ,int playerEnum , List<Classes.GameScripts.Team> teams)
        {
            using (Packet packet = new Packet((int)ServerPackets.MatchStarted))
            {
                packet.Write(teamEnum);
                packet.Write(playerEnum);
                packet.Write(toClient);
                packet.Write(teams.Count);
                for (int i = 0; i < teams.Count; i++)
                {
                    packet.Write(teams[i].Players.Count);
                    for (int j = 0; j < teams[i].Players.Count; j++)
                    {
                        packet.Write((int)teams[i].Players[j].TeamEnum);
                        packet.Write((int)teams[i].Players[j].PlayerEnum);
                        packet.Write(teams[i].Players[j].ID);
                    }
                }
                SendTCPData(toClient, packet);
            }
        }
    }
}
