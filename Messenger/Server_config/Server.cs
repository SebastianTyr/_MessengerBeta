using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_config
{
    public class Server
    {
        public void Start_server()
        {
            try
            {
                //Local IP address - the same on the client side
                IPAddress ip = IPAddress.Parse("192.168.0.101");

                //Initialize the listener
                TcpListener listener = new TcpListener(ip, 8001);

                //Start listening at the specified port
                listener.Start();
                Console.WriteLine("Serwer działa na porcie 8001");
                Console.WriteLine($"Local End point: {listener.LocalEndpoint}");
                Console.WriteLine("Oczekiwanie na połączenie...");

                Socket socket = listener.AcceptSocket();
                Console.WriteLine($"Połączenie zaakceptowane z {socket.RemoteEndPoint}");

                byte[] b = new byte[100];
                int receive = socket.Receive(b);
                Console.WriteLine("Odbieranie...");

                for (int i = 0; i < receive; i++)
                    Console.Write(Convert.ToChar(b[i]));

                ASCIIEncoding encoding = new ASCIIEncoding();
                socket.Send(encoding.GetBytes("Wiadomość odebrana przez serwer"));
                Console.Write("\nOdebranie potwierdzenie");

                //clean up
                socket.Close();
                listener.Stop();

                Console.WriteLine();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd... {e.StackTrace}");
            }
        }
    }
}
