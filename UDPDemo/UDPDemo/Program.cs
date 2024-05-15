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
                Console.WriteLine("Enter Remote IP: ");
                _remoteAddr = IPAddress.Parse(Console.ReadLine());
                Console.WriteLine("Enter Remote Port: ");
                _remotePort = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Local Port: ");
                _localPort = int.Parse(Console.ReadLine());

                Thread workingThread = new Thread(new ThreadStart(RecieveData));
                workingThread.IsBackground = true;
                workingThread.Start();
                Console.ForegroundColor = ConsoleColor.Red;
                while (true)
                {
                    SendData(Console.ReadLine());
                }
            }
            catch(FormatException ForEx)
            {
                Console.WriteLine($"\n> Runtime Exception: {ForEx.Message}");
            }
            catch (Exception runEx)
            {
                Console.WriteLine($"\n> Runtime Exception: {runEx.Message}");
            }
            finally
            {
                Console.WriteLine("\n\n Finish");
            }
        }

        private static void RecieveData() 
        {
            try
            {
                while (true)
                {
                    UdpClient udpClient = new UdpClient(_localPort);
                    IPEndPoint remoteEP = null;
                    byte[] data = udpClient.Receive(ref remoteEP);
                    string message = Encoding.UTF8.GetString(data);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.Red;
                    udpClient.Close();
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
