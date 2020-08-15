using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TNDDMMainServer
{
    class Server
    {
        public static int MaxPlayers { get; private set; }
        public static int Port { get; private set; }

        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();

        public delegate void PacketHandler(int fromClient, Packet packet);
        public static Dictionary<int, PacketHandler> packetHandlers;

        private static TcpListener tcpListener;

        public static void StartServer(int maxPlayers ,int port)
        {
            MaxPlayers = maxPlayers;
            Port = port;

            InitializeServerData();

            tcpListener = new TcpListener(IPAddress.Any, port);

            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            Console.WriteLine($"Server started on {Port}.");
        }

        private static void TCPConnectCallback(IAsyncResult result)
        {
            TcpClient client = tcpListener.EndAcceptTcpClient(result);
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            Console.WriteLine($"Incoming connection from : {client.Client.RemoteEndPoint}");

            for (int i = 1; i <= MaxPlayers; i++)
            {
                if(clients[i].tcp.socket == null)
                {
                    clients[i].tcp.Connect(client);
                    return;
                }
            }

            Console.WriteLine($"{client.Client.RemoteEndPoint} failed to connect : Server is full..");
        }

        private static void InitializeServerData()
        {
            for (int i = 1; i <= MaxPlayers; i++)
            {
                clients.Add(i, new Client(i));
            }

            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                {(int)ClientPackets.Token , ServerHandle.TokenReceived },
                {(int)ClientPackets.LobbyRoomRequest , ServerHandle.LobbyRoomRequest },
                {(int)ClientPackets.CreateRoom , ServerHandle.CreateRoom },
                {(int)ClientPackets.LoginRoom , ServerHandle.LoginRoom },
                {(int)ClientPackets.ToggleReady , ServerHandle.ToggleReady },
                {(int)ClientPackets.ExitRoom , ServerHandle.ExitRoom }
            };
        }
    }
}
