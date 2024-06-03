using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace MultiChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MulticastSend(string message)
        {
            // 1 - Creation of UDP Socket to send messages 
            Socket socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp
            );

            // 2 - Set time to live of datagram
            socket.SetSocketOption(
                SocketOptionLevel.IP,
                SocketOptionName.MulticastTimeToLive,
                2
            );

            // 3 - Registration of special adress of mass send
            IPAddress addr = IPAddress.Parse("224.5.5.5");
            socket.SetSocketOption(
                SocketOptionLevel.IP,
                SocketOptionName.AddMembership,
                new MulticastOption(addr)
            );

            // 4 - Create endpoint and connect to service
            IPEndPoint ep = new IPEndPoint(addr, 9001);
            socket.Connect(ep);

            // 5 - Send Message
            byte[] data = Encoding.UTF8.GetBytes(message);
            socket.Send(data);

            // 6 - Close sending socket
            socket.Close();
        }

        private void MulticastReceive()
        {
            while (true)
            {
                // 1 - Creation of UDP Socket to receive messages 
                Socket socket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Dgram,
                    ProtocolType.Udp
                );

                // 2 - Create Endpoint
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 9001);
                socket.Bind(ep);

                // 3 - Sign method recieve to receive messages
                IPAddress addr = IPAddress.Parse("224.5.5.5");
                socket.SetSocketOption(
                    SocketOptionLevel.IP,
                    SocketOptionName.AddMembership,
                    new MulticastOption(addr, IPAddress.Any)
                );

                // 4 - Receive message
                byte[] buff = new byte[1024];
                socket.Receive(buff);
                string mess = Encoding.UTF8.GetString(buff);

                //5 Show message
                Dispatcher.Invoke(new Action(() =>
                {
                    ChatBox.Text += mess;
                }));

                // 5 - Close socket
                socket.Close();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageField.Clear();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string nick = NickNameField.Text;
            string mess = MessageField.Text;
            if(string.IsNullOrEmpty(nick) ||
                string.IsNullOrEmpty(mess)) 
            {
                System.Windows.Forms.MessageBox.Show("You have not entered all fields", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string message = DateTime.Now + " => " + nick + " :: " + mess + "\r\n";
                MulticastSend(message);
                MessageField.Clear();
                MessageField.Focus();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread listenThread = new Thread(new ThreadStart(MulticastReceive));
            listenThread.IsBackground = true;
            listenThread.Start();
        }
    }
}
