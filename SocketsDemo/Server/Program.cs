using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 - Create parameters of connection
            int port = 9001;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, port);

            //2 - Create server current socket
            Socket listener = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP
            );

            //3 - Start server socket
            int queueLength = 10;
            listener.Bind(ep);
            listener.Listen(queueLength);

            //4 - Start cycle to work with clients
            try 
            { 
                while(true)
                {
                    //4.1. Waiting, connection and creation of accepting socket
                    Console.WriteLine("\n> Waiting for connection attempts");

                    Socket acceptor = listener.Accept();

                    //4.2 Recieving of input message from client
                    byte[] buff = new byte[1024];
                    int bytes = acceptor.Receive(buff);

                    //4.3 Decoding of recieved message
                    string message = Encoding.UTF8.GetString(buff, 0, bytes);
                    Console.WriteLine($"    {DateTime.Now} -> {message}");

                    //4.4 Parsing of recieved message
                    string response = "This is response of server";

                    //4.5 Encoding and sending of response to client
                    byte[] buff2 = new byte[1024];
                    buff2 = Encoding.UTF8.GetBytes(response);
                    acceptor.Send(buff2);

                    //4.6 End of connection with client
                    acceptor.Shutdown(SocketShutdown.Both);
                    acceptor.Close();

                    //4.7 Check for force stop
                    if (message == "STOP-123")
                        break;
                }
                listener.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Server error: {ex.Message}");
            }
            finally
            {
                listener?.Close();
                Console.WriteLine("> Client was stopped");
            }
        }
    }
}
