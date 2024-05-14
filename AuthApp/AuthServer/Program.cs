using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string login = "";
            string password = "";
            string clientMessage = "";
            string serverMessage = "";
            TcpListener listener = null;

            var usersDb = new UsersDb();
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9001);
                listener.Start(10);
                Console.WriteLine($"\n> Server started on port 9001");

                while(true)
                {

                    Console.WriteLine($"\n> Server is waiting for client queries...");

                    TcpClient acceptor = listener.AcceptTcpClient();
                    NetworkStream ns = acceptor.GetStream();
                    StreamReader streamReader = new StreamReader(ns);

                    clientMessage = streamReader.ReadLine();
                    Console.WriteLine($"\n> {DateTime.Now} -> {clientMessage}");
                    string[] parts = clientMessage.Split('#');

                    login = parts[0];
                    password = parts[1];
                    password = HashManager.GetHash(password);

                    var linqResult = usersDb.Accounts
                        .Where(a => a.Login == login && a.Password == password)
                        .FirstOrDefault();

                    if (linqResult == null)
                        serverMessage = "FAILED";
                    else
                        serverMessage = "OK";

                    StreamWriter sw = new StreamWriter(ns);
                    sw.Flush();
                    sw.WriteLine(serverMessage);

                    sw.Close();
                    streamReader.Close();
                    ns.Close();

                    acceptor.Close();

                    if (login == "STOP-SERVER")
                        break;
                }
            }
            catch(SocketException ex) {
                Console.WriteLine($"\n> Server socket error: \n {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\n> Server runtime error: \n {ex.Message}");
            }
            finally
            {
                listener?.Stop();
                Console.WriteLine($"\n> Server has been stopped");
            }
        }
    }
}
