using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 - Create parameters of connection
            int port = 9001;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, port);

            //2 - Create a cycle to send messages to server
            try
            {
                string ans = "y";
                while(ans ==  "y")
                {
                    //2.1 Dialogue to enter message
                    Console.Write("\n> Enter message: ");
                    string message = Console.ReadLine();

                    //2.2 Create client current socket
                    Socket sender = new Socket(
                        AddressFamily.InterNetwork,
                        SocketType.Stream,
                        ProtocolType.IP
                    );

                    //2.3 Connect to server
                    sender.Connect(ep);

                    //2.4 Encode and send message to server
                    byte[] buff1 = Encoding.UTF8.GetBytes(message);
                    sender.Send(buff1);

                    //2.5 Recieve response from server
                    byte[] buff2 = new byte[1024];
                    int bytes = sender.Receive(buff2);

                    //2.6 Decode and print response from server
                    string response = Encoding.UTF8.GetString(buff2, 0 ,bytes);
                    Console.WriteLine($"    Response from server: {response}");

                    //2.7 Close connection with server
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                    //2.8 Check for force stop
                    if (message == "STOP-123")
                        break;

                    //2.9 Check for continuation
                    Console.Write("\n More messages (y/n) - ");
                    ans = Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Client error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("> Client was stopped");
            }
        }
    }
}
