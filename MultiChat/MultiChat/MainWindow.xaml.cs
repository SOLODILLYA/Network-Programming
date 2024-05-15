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

        }

        private void MulticastReceive()
        {

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
    }
}
