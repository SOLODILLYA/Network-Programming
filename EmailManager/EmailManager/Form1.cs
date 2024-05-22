using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Entity;
using EmailManager.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;

namespace EmailManager
{
    public partial class Form1 : Form
    {
        private static string _filePath1;
        private static string _filePath2;
        EmailDatabase _context = new EmailDatabase();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _context.Contacts.Load();
            _context.Messages.Load();
            ContactsList.DataSource = _context.Contacts.Local.ToBindingList();
            ContactsList.DisplayMember = "Email";
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                _filePath1 = @"..\..\Credentials\username.txt";
                _filePath2 = @"..\..\Credentials\password.txt";

                string username = ReadUsername();
                string password = ReadPassword();

                MailAddress from = new MailAddress("myapp@somee.com");
                MailAddress to = new MailAddress("test@test.com");
                if (!string.IsNullOrWhiteSpace(ToField.Text))
                {
                    to = new MailAddress(ToField.Text);
                }
                else
                {
                    throw new Exception("Please enter to who send the email");
                }

                MailMessage mm = new MailMessage(from, to);
                if (!string.IsNullOrWhiteSpace(SubjectField.Text))
                {
                    mm.Subject = SubjectField.Text;
                }
                else
                {
                    throw new Exception("Please enter subject of email");
                }
                if (!string.IsNullOrWhiteSpace(MessageField.Text))
                {
                    mm.Body = MessageField.Text;
                }
                else
                {
                    throw new Exception("Please enter message of email");
                }

                if(SelFilesList.Items.Count > 0)
                {
                    foreach (string path in SelFilesList.Items)
                    {
                        var att = new Attachment(path);
                        mm.Attachments.Add(att);
                    }
                }

                int port = 2525;
                string host = "sandbox.smtp.mailtrap.io";
                var client = new SmtpClient(host, port);

                client.Credentials = new NetworkCredential(username, password);
                client.EnableSsl = true;
                client.Send(mm);

                var contact = _context.Contacts.FirstOrDefault(c => c.Email == ToField.Text);
                if (contact == null)
                {
                    contact = new Contact()
                    {
                        Email = ToField.Text,
                    };
                    _context.Contacts.Add(contact);
                }
                var newMessage = new Models.Message()
                {
                    Subject = SubjectField.Text,
                    Body = MessageField.Text,
                    To = ToField.Text,
                    SentDate = DateTime.Now,
                    ContactId = contact.Id,
                    Contact = contact
                };
                _context.Messages.Add(newMessage);
                _context.SaveChanges();
                
                MessageBox.Show("Email was sent successfuly");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        static string ReadUsername()
        {
            using (FileStream fs = new FileStream(_filePath1, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
                return sr.ReadLine();
        }
        static string ReadPassword()
        {
            using (FileStream fs = new FileStream(_filePath2, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
                return sr.ReadLine();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            openFileDialog.Title = "Select a file";

            openFileDialog.Multiselect = true;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string[] selectedFiles = openFileDialog.FileNames;

                foreach (string file in selectedFiles)
                {
                    PreFilesList.Items.Add(file);
                    MessageBox.Show(file);
                }
            }
            else
            {
                MessageBox.Show("Operation cancelled.");
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            foreach(string file in PreFilesList.Items)
            {
                SelFilesList.Items.Add(file);
            }
            PreFilesList.Items.Clear();
        }

        private void ContactsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedContact = ContactsList.SelectedItem as Contact;
            if (selectedContact != null)
            {
                var messages = selectedContact.Messages.ToList();
                CopiesList.DataSource = messages;
                CopiesList.DisplayMember = "Subject";
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            SubjectField.Clear();
            ToField.Clear();
            MessageField.Clear();
            PreFilesList.Items.Clear();
            SelFilesList.Items.Clear();
        }
    }
}
