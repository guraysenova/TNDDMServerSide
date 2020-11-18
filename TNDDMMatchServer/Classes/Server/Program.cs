using System;
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
            Console.WriteLine("test");
            int port = int.Parse(args[0]);

            Match = new Match(args[1], args[2], args[3], args[4], args[5], args[6] , args[7]);
            
            Server.StartServer(2, port);
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

        public static Match Match { get; private set; }
    }
}
