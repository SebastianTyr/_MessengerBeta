using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client_config
{
    public class Client
    {
        public void Start_client()
        {
            try
            {
                //local client IP
                TcpClient client = new TcpClient();
                client.Connect("192.168.0.101", 8001);

                Console.WriteLine("Połączono");
                Console.Write("Wpisz wiadomość: ");

                string mess = Console.ReadLine();
                Stream stream = client.GetStream();

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] b = encoding.GetBytes(mess);
                Console.WriteLine("Przesyłanie...");

                stream.Write(b, 0, b.Length);

                byte[] bb = new byte[100];
                int k = stream.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                client.Close();

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
