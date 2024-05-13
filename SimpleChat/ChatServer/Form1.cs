using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        private int _port;
        private IPAddress _address;
        private IPEndPoint _ep;
        private Socket _listener;
        private Thread _workThread;
        public Form1()
        {
            InitializeComponent();
        }

        private void ThreadMethod()
        {
            byte[] buff1 = new byte[1024];
            byte[] buff2 = new byte[1024];
            string clientMessage = string.Empty;
            string serverMessage = string.Empty;
            int receivedBytes = 0;

            try
            {
                while (true)
                {
                    Socket acceptor = _listener.Accept();
                    receivedBytes = acceptor.Receive(buff1);
                    clientMessage = Encoding.UTF8.GetString(buff1, 0, receivedBytes);
                    if(clientMessage == "GET_CHAT")
                    {
                        ChatBox.Invoke(new Action(() =>
                        {
                            serverMessage = ChatBox.Text;
                        }));
                        buff2 = Encoding.UTF8.GetBytes(serverMessage);
                        acceptor.Send(buff2);
                    }
                    else 
                    {
                        string[] parts = clientMessage.Split(':');
                        if (parts[0] == "SAVE_POST")
                        {
                            ChatBox.Invoke(new Action(() =>
                            {
                                ChatBox.Text += DateTime.Now + " -> " + parts[1].Trim() + "\r\n";
                            }));
                        }
                    }
                    acceptor.Shutdown(SocketShutdown.Both);
                    acceptor.Close();
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                _address = IPAddress.Parse(IPTextBox.Text);
                _port = int.Parse(PortTextBox.Text);
                _ep = new IPEndPoint(_address, _port);

                _listener = new Socket(AddressFamily.InterNetwork, 
                    SocketType.Stream, ProtocolType.IP);
                _listener.Bind(_ep);
                _listener.Listen(10);

                _workThread = new Thread(new ThreadStart(ThreadMethod));
                _workThread.IsBackground = true;
                _workThread.Start();

                StartServerButton.Enabled = false;
                StopServerButton.Enabled = true;
                label1.ForeColor = Color.Green;
                label1.Text = "Server is working";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error server start", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                StartServerButton.Enabled = true;
                StopServerButton.Enabled = false;
                label1.ForeColor = Color.Red;
                label1.Text = "Server is not working";
                _workThread.Suspend();
                _listener.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error server stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(_listener != null)
                {
                    _workThread.Suspend();
                    _listener.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error program stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
