using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace AuthClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var choice = string.Empty;
            var login = string.Empty;
            var password = string.Empty;

            var clientMessage = string.Empty;
            var serverMessage = string.Empty;
            TcpClient client = null;

            try
            {
                while(true)
                {
                    Console.WriteLine("\n> Enter your credentials: ");
                    Console.Write(" Login -> ");
                    login = Console.ReadLine();
                    Console.Write(" Password -> ");
                    password = Console.ReadLine();

                    client = new TcpClient();
                    clientMessage = $"{login}#{password}";
                    client.Connect(IPAddress.Parse("127.0.0.1"), 9001);
                    Console.WriteLine("\n> Client has been connected to server");

                    NetworkStream ns = client.GetStream();
                    StreamWriter sw = new StreamWriter(ns);
                    sw.WriteLine(clientMessage);
                    sw.Flush();

                    StreamReader sr = new StreamReader(ns); 
                    serverMessage = sr.ReadLine();
                    Console.WriteLine($"\n> Server Response: {serverMessage}");

                    if (serverMessage == "OK")
                        Console.WriteLine(" Your authentification was successfull");
                    else
                        Console.WriteLine(" Your authentification was unsuccessfull");

                    sr.Close();
                    sw.Close();
                    ns.Close();

                    client.Close();

                    Console.Write("\n> Finish (y/n)? - ");
                    choice = Console.ReadLine();
                    if (choice == "y")
                        break;
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"\n> Client socket error: \n {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n> Client runtime error: \n {ex.Message}");
            }
            finally
            {
                client?.Close();
                Console.WriteLine($"\n> Client has been stopped");
            }
        }
    }
}
