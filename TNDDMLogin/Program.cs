using System;

namespace TNDDMLogin
{
    class LoginServer
    {
        static void Main(string[] args)
        {
            Console.Title = "TNDDM Login Server";

            Server.StartServer(100, 26950);

            Console.ReadKey();
        }
    }
}
