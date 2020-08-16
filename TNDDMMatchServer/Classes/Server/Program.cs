using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TNDDMMatchServer
{
    class MatchServer
    {
        static string version = "v0.1a";

        private static bool isRunning = false;

        static void Main(string[] args)
        {
            Console.Title = "TNDDM Match Server" + " " + version;

            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            // TODO: GET PORT FROM DATABASE!!!!!!!!

            //Server.StartServer(100, 26951);
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
