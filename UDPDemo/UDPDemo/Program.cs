using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UDPDemo
{
    internal class Program
    {
        private static int _localPort;
        private static int _remotePort;
        private static IPAddress _remoteAddr;
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {

                }
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine("ReceiveData Socket Exception:" + sockEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReceiveData Runtime Exception" + ex.Message);
            }
        }

        private static void RecieveData() { }
        private static void SendData(string message) {
            UdpClient udpClient = new UdpClient();
            IPEndPoint remoteEP = new IPEndPoint(_remoteAddr, _remotePort);
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, remoteEP);
                udpClient.Close();
            }
            catch(SocketException sockEx)
            {
                Console.WriteLine("SendData Socket Exception:" + sockEx.Message);
            }catch(Exception ex)
            {
                Console.WriteLine("SendData Runtime Exception" + ex.Message);
            }finally
            {
                udpClient?.Close();
            }
        }
    }
}
