using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DotNetCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry("myhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 9000);

            Console.WriteLine("accept0");

            Socket listener = new Socket(ipAddress.AddressFamily,
                  SocketType.Stream, ProtocolType.Tcp);
            
            Console.WriteLine("Waiting for connections on " + localEndPoint);
            
            listener.Bind(localEndPoint);
            Console.WriteLine("accept1");
            listener.Listen(1);
            Console.WriteLine("accept2");
            Socket handler = listener.Accept();

            //Console.WriteLine("Handler: " + handler);
            
            String data = null;
            Console.WriteLine("handler: " +handler);
            while (true)
            {
                byte[] bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                String c = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine("Received: " + c);
                data += c;
                if (data.IndexOf("Q") > -1)
                {
                    break;
                }
            }

            Console.WriteLine("Text received : {0}", data);
            
            byte[] msg = Encoding.ASCII.GetBytes(data);
            handler.Send(msg);
            
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            
            Console.WriteLine("Closing the listener...");
            Console.ReadKey();
        }
    }
}
