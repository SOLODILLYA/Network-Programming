using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppServer
{
    public partial class Form1 : Form
    {
        private int port;
        private IPAddress addr;
        private IPEndPoint ep;

        TcpListener listener = null;
        private Thread _workThread;
        private BinaryFormatter bf;

        private readonly Model1 _db;
        public Form1()
        {
            InitializeComponent();

            port = 9001;
            addr = IPAddress.Parse("127.0.0.1");
            ep = new IPEndPoint(addr, port);

            _db = new Model1();
            _db.Configuration.ProxyCreationEnabled = false;// Needed to be turned off in order for deserelization to work
            bf = new BinaryFormatter();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            
        }

        

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
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

        private void Form1_Load(object sender, EventArgs e)
        {
            const int N = 10;
            listener = new TcpListener(ep);
            listener.Start(N);
            Console.WriteLine($"\n> Server started on port 9001");
            try
            {
                _workThread = new Thread(new ThreadStart(ThreadMethod));
                _workThread.IsBackground = true;
                _workThread.Start();
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
                    MyResponse response = new MyResponse();
                    switch (request.Header)
                    {
                        case "AUTH":
                            User user = request.AuthUser;
                            var checkUser = _db.Users.Where(u => u.Login == user.Login && u.Password == user.Password).FirstOrDefault();
                            if (checkUser != null)
                            {
                                response.Message = "OK";
                            }
                            else
                            {
                                response.Message = "FAILED";
                            }
                            JournalPanel.Invoke(new Action(() =>
                            {
                                JournalPanel.Text += DateTime.Now + " :: AUTH: " +
                                    user.Login + "/" + user.Password + " => " +
                                    response.Message + "\n";
                            }));
                            bf.Serialize(ns, response);
                            break;
                        case "REG":
                            User regUser = request.RegistryUser; 
                            User checkRegUser = null;
                            if (regUser != null)
                            {
                                checkRegUser = _db.Users.Where(u => u.Login == regUser.Login).FirstOrDefault();
                            }
                            if(checkRegUser != null)
                            {
                                response.Message = "EXISTS";
                            }
                            else
                            {
                                _db.Users.Add(regUser);
                                response.Message = "REGISTRED";
                            }
                            _db.SaveChanges();
                            JournalPanel.Invoke(new Action(() =>
                            {
                                JournalPanel.Text += DateTime.Now + " :: REGISTRY: " +
                                    regUser.Login + "/" + regUser.Password + " => " +
                                    response.Message + "\n";
                            }));
                            bf.Serialize(ns, response);
                            break;
                        case "GET":
                            string owner = request.AuthUser.Login;
                            var targetUser = _db.Users.Where(u => u.Login == owner).FirstOrDefault();

                            if (targetUser != null)
                            {
                                var tasks = _db.MyTasks.Where(t => t.UserId == targetUser.Id).ToList();
                                response.MyTasks = tasks;
                                response.Message = "TASKS";
                            }
                            else
                            {
                                response.Message = "USER_NOT_FOUND";
                            }

                            bf.Serialize(ns, response);
                            break;
                        case "NEW":
                            break;
                        case "EDIT":
                            break;
                        case "DEL":
                            break;
                        default:
                            response.Message = "FAILED";
                            bf.Serialize(ns, response);
                            break;

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
    }
}
