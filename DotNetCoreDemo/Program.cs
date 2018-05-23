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
            Console.WriteLine("initialising...");

            //change to "myhost" to "localhost" if executed from VS directly
            IPAddress ipAddress = null;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
			
			//picking the first suitable IP address
            foreach (var address in ipHostInfo.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = address;
                    break;
                }
            }
            
			//prepare endpoint and socket
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 9000);
            Socket listener = new Socket(ipAddress.AddressFamily,
                  SocketType.Stream, ProtocolType.Tcp);
            
            Console.WriteLine("Waiting for connections on " + localEndPoint);
            
			//bind and accept
            listener.Bind(localEndPoint);
            listener.Listen(1);
            Socket handler = listener.Accept();
            
            String data = "";
            Console.WriteLine("Press 'Q' to quit");

			//loop while exit character has been typed
            while (data.IndexOf("Q") <= -1)
            {
                byte[] bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                String c = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine("Received: " + c);
                data += c;
            }

			
            Console.WriteLine("Text received : {0}", data);
            
			//echo back the complete message and die
            byte[] msg = Encoding.ASCII.GetBytes(data);
            handler.Send(msg);
            
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            
            Console.WriteLine("Closing the listener...");
        }
    }
}
