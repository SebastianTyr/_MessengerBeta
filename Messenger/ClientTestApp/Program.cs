using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_config;

namespace ClientTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Start_client();
        }
    }
}
