using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TNDDMMainServer
{
    class MainServer
    {
        static string version = "v0.1a";
        private static bool isRunning = false;

        static void Main(string[] args)
        {
            Console.Title = "TNDDM Main Server" + " " + version;

            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Server.StartServer(100, 26951);

            //LobbyRoomsManager.CreateRoom("TESTUUID", "Helloo :)");
        }

        private static void MainThread()
        {
            Console.WriteLine($"Main thread started. Running at {Constants.TicksPerSec} ticks per second");
            DateTime nextLoop = DateTime.Now;

            while (isRunning)
            {
                while(nextLoop < DateTime.Now)
                {
                    LoginLogic.Update();

                    nextLoop = nextLoop.AddMilliseconds(Constants.MilSecPerTick);

                    if(nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}
