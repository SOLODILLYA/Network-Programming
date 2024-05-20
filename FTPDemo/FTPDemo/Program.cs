using FTPDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            string host = "ftp://*********.somee.com/www.*********.somee.com";
            string user = "User";
            string password = "Password";

            //2
            var client = new MyFtpClient(host, user, password);
            string remoteFile = "/Temp/download.jpg";
            string localFile = @"..\..\DownloadFIles\smile1.jpg";

            //3
            client.Download(remoteFile, localFile);

            Console.WriteLine("\n> Provided file was successfuly downloaded to DownloadFiles Directory");
        }
    }
}
