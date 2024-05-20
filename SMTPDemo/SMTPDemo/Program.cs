using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace SMTPDemo
{
    internal class Program
    {
        private static string filePath1;
        private static string filePath2;
        static void Main(string[] args)
        {
            //1
            filePath1 = @"..\..\Credentials\username.txt";
            filePath2 = @"..\..\Credentials\password.txt";

            //2
            string username = ReadUsername();
            string password = ReadPassword();

            //3
            MailAddress from = new MailAddress("myapp@somee.com");
            MailAddress to = new MailAddress("test-customer@somee.com");

            //4 
            MailMessage mm = new MailMessage(from, to);
            mm.Subject = "Connection with customer test";
            mm.Body = "One Two Three";

            //5
            string path = @"..\..\Images\download.jpg";
            var att = new Attachment(path);
            mm.Attachments.Add(att);

            //6
            int port = 2525;
            string host = "sandbox.smtp.mailtrap.io";
            var client = new SmtpClient(host, port);

            //7
            client.Credentials = new NetworkCredential(username, password);
            client.EnableSsl = true;
            client.Send(mm);

            //8
            Console.WriteLine("\n> Message was sent successfuly");
        }

        static string ReadUsername()
        {
            using (FileStream fs = new FileStream(filePath1, FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                    return sr.ReadLine();
        }
        static string ReadPassword()
        {
            using (FileStream fs = new FileStream(filePath2, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
                return sr.ReadLine();
        }
    }
}
