using System;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Game Server";

            Server.Start(5, 2049);

            Console.ReadKey();
        }
    }
}
