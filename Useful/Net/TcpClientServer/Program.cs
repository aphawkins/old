using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task serverTask = new Task(() => StartServer());
            serverTask.Start();

            Thread.Sleep(10000);

            // IPAddress address = IPAddress.Parse("173.194.41.159");
            // IPEndPoint remoteEP = new IPEndPoint(address, 80);

            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);

            GetData(client, "Client sends: Hello from client");

            //using (NetworkStream data = client.GetStream())
            //{
            //    byte[] buffer = Encoding.UTF8.GetBytes("Hello from client");
            //    data.Write(buffer, 0, buffer.Length);
            //    Console.WriteLine("Client sends: " + "Hello from client");
            //    Thread.Sleep(10000);

            //    buffer = new byte[200];
            //    int i = data.Read(buffer, 0, buffer.Length);
            //    if (i > 0)
            //    {
            //        string dataString = Encoding.UTF8.GetString(buffer);
            //        Console.WriteLine("Client receives: " + dataString);
            //    }
            //}

            Console.Read();
        }

        private static void StartServer()
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            server.Start();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                GetData(client, "Hello from server.");
            }
        }

        private static void GetData(TcpClient client, string toSend)
        {
            using (NetworkStream data = client.GetStream())
            {
                byte[] buffer = new byte[200];
                int i = data.Read(buffer, 0, buffer.Length);
                if (i > 0)
                {
                    string dataString = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("Server received: " + dataString);

                    buffer = Encoding.UTF8.GetBytes(toSend);

                    data.Write(buffer, 0, buffer.Length);

                    Console.WriteLine("Server sent: " + toSend);
                }
            }
        }
    }
}
