using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horoscope
{
    public partial class Form1 : Form
    {
        private int _port;
        private IPAddress _address;
        private IPEndPoint _ep;
        private Socket _client;

        private byte[] _buff2;
        private byte[] _buff1;
        private string _clientMessage;
        private string _serverMessage;
        private int _receivedBytes;
        public Form1()
        {
            InitializeComponent();
            _buff2 = new byte[1024];
            _buff1 = new byte[1024];
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = false;
            DisconnectButton.Enabled = true;
            SendButton.Enabled = true;

            try
            {
                _address = IPAddress.Parse(IPTextBox.Text);
                _port = int.Parse(PortTextBox.Text);
                _ep = new IPEndPoint(_address, _port);

                _client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.IP);
                _client.Connect(_ep);

                _clientMessage = "GET_SIGNS:" + UserTextBox.Text + " connected to server\n";
                _buff1 = Encoding.UTF8.GetBytes(_clientMessage);
                _client.Send(_buff1);
                _receivedBytes = _client.Receive(_buff2);
                _serverMessage = Encoding.UTF8.GetString(_buff2, 0, _receivedBytes);
                string[] parts = _serverMessage.Split(':');
                ZodiacSign.Enabled = true;
                if (parts[0] == "SIGNS")
                {
                    for(int i = 1; i < parts.Length; i++)
                    {
                        ZodiacSign.Items.Add(parts[i]);
                    }
                    ZodiacSign.SelectedIndex = 0;
                }

                _client.Shutdown(SocketShutdown.Both);
                _client.Close();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Connecting to Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;
            SendButton.Enabled = false;

            try
            {
                _client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.IP);
                _client.Connect(_ep);

                _clientMessage = "GET_SIGNS:" + UserTextBox.Text + " disconnected from server\n";
                _buff1 = Encoding.UTF8.GetBytes(_clientMessage);
                _client.Send(_buff1);

                _client.Shutdown(SocketShutdown.Both);
                _client.Close();
                timer1.Stop();

                ZodiacBox.Clear();
                ZodiacSign.Items.Clear();
                ZodiacSign.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Disconnecting from Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                _client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.IP);
                _client.Connect(_ep);

                _clientMessage = "GET_HOROSCOPE:" + ZodiacSign.SelectedItem.ToString() +":" + UserTextBox.Text;
                _buff1 = Encoding.UTF8.GetBytes(_clientMessage);
                _client.Send(_buff1);
                _receivedBytes = _client.Receive(_buff2);
                _serverMessage = Encoding.UTF8.GetString(_buff2, 0, _receivedBytes);                
                ZodiacBox.Text += _serverMessage;

                _client.Shutdown(SocketShutdown.Both);
                _client.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Sending Message to Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
