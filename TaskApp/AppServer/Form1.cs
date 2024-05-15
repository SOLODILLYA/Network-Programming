using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppServer
{
    public partial class Form1 : Form
    {
        TcpListener listener = null;
        private Thread _workThread;
        private BinaryFormatter bf;
        public Form1()
        {
            InitializeComponent();
            bf = new BinaryFormatter();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9001);
                listener.Start(10);
                Console.WriteLine($"\n> Server started on port 9001");

                _workThread = new Thread(new ThreadStart(ThreadMethod));
                _workThread.IsBackground = true;
                _workThread.Start();
                StartButton.Enabled = false;
                StopButton.Enabled = true;
                label1.Text = "Server is Running";
                label1.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error server start", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ThreadMethod()
        {
            try
            {
                while (true)
                {
                    TcpClient acceptor = listener.AcceptTcpClient();
                    NetworkStream ns = acceptor.GetStream();
                    MyRequest request = (MyRequest)bf.Deserialize(ns);
                    if (request.Header == "AUTH")
                    {
                        MyResponse response = new MyResponse()
                        {
                            Message = "OK"
                        };
                        bf.Serialize(ns, response);
                    }
                    else
                    {
                        MyResponse response = new MyResponse()
                        {
                            Message = "Failed"
                        };
                        bf.Serialize(ns, response);
                    }
                    ns.Close();
                    acceptor.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error server runtime", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                StartButton.Enabled = true;
                StopButton.Enabled = false;
                label1.Text = "Server is stopped";
                label1.ForeColor = Color.Red;
                if(listener != null)
                {
                    _workThread.Suspend();
                    listener.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error server stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
