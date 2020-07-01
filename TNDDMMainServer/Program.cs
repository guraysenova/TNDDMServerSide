using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TNDDMMainServer
{
    class MainServer
    {
        private static bool isRunning = false;

        static void Main(string[] args)
        {
            Console.Title = "TNDDM Main Server";

            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Server.StartServer(100, 26951);
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
