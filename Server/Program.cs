﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Server;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new GameServer())
                server.Start();
        }
    }
}
