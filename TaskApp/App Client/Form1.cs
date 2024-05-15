using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Net;
using Models;

namespace App_Client
{
    public partial class Form1 : Form
    {
        private int port;
        private IPAddress addr;
        private IPEndPoint ep;

        private TcpClient client;
        private BinaryFormatter bf;
        private string state;
        public Form1()
        {
            InitializeComponent();
            port = 9001;
            addr = IPAddress.Parse("127.0.0.1");
            ep = new IPEndPoint(addr, port);
            bf = new BinaryFormatter();
            state = "GUEST";
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string requestKey = "AUTH";
                string login = LoginTextBox.Text;
                string password = PasswordTextBox.Text;
                password = HashManager.GetHash(password);

                var request = new MyRequest()
                {
                    Header = requestKey,
                    AuthUser = new User()
                    {
                        Id = 0,
                        Login = login,
                        Password = password
                    }
                };

                client = new TcpClient();
                client.Connect(ep);
                NetworkStream ns = client.GetStream();
                bf.Serialize(ns, request);

                MyResponse response = (MyResponse)bf.Deserialize(ns);
                string message = response.Message;
                if (message == "OK")
                {
                    state = login;
                    MessageBox.Show("Authorization successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetTasksButton.Enabled = true;
                    NewTaskButton.Enabled = true;
                    EditTaskButton.Enabled = true;
                    DeleteTaskButton.Enabled = true;
                    ConnectButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Authorization unsuccessful", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ns.Close();
                client.Close();
            }catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
