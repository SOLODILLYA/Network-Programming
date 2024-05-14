using System;
using System.Collections.Generic;
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
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9001);
                listener.Start(10);

                while(true)
                {
                    TcpClient acceptor = listener.AcceptTcpClient();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
