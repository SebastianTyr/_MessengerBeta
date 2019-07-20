using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerTestApp
{
    class Program
    {
        static void Main(string[] args)
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
                    Console.WriteLine(Convert.ToChar(b[i]));

                ASCIIEncoding encoding = new ASCIIEncoding();
                socket.Send(encoding.GetBytes("Wiadomość odebrana przez serwer"));
                Console.WriteLine("\nOdebranie potwierdzenie");

                //clean up
                socket.Close();
                listener.Stop();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd... {e.StackTrace}");
            }
        }
    }
}
