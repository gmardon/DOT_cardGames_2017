using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new GameServer();
            server.Start();
        }
    }
}
