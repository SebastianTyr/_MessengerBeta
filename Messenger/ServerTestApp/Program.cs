using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server_config;

namespace ServerTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start_server();
        }
    }
}
