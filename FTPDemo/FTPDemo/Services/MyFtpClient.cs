using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FTPDemo.Services
{
    internal class MyFtpClient
    {
        private string host = null;
        private string pass = null;
        private string user = null;

        private FtpWebRequest request = null;
        private FtpWebResponse response = null;
        private Stream ftpStream = null;

        private int buffSize = 2048;
        public MyFtpClient(string host, string pass, string user)
        {
            this.host = host;
            this.pass = pass;
            this.user = user;
        }

        public void Download(string remoteFile, string localFile)
        {
            try
            {
                request = (FtpWebRequest)FtpWebRequest.Create($"{host}/{remoteFile}");
                request.Credentials = new NetworkCredential(user, pass);
                request.UseBinary = true;

                //2
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                //3
                response = (FtpWebResponse)request.GetResponse();
                ftpStream = response.GetResponseStream();
                FileStream localFileStream = new FileStream(localFile, FileMode.Create);

                byte[] byteBuff = new byte[buffSize];
                int bytesRead = ftpStream.Read(byteBuff, 0, buffSize);

                try
                {
                    while(bytesRead > 0)
                    {
                        localFileStream.Write(byteBuff, 0, bytesRead);
                        bytesRead = ftpStream.Read(byteBuff, 0, buffSize);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n> Copy Exception: {ex.Message}");
                }

                localFileStream.Close();
                ftpStream.Close();
                response.Close();
                request = null;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"\n> Download Exception: {ex.Message}");
            }
        }

        public void Upload(string remoteFile, string localFile)
        {
            try
            {
                request = (FtpWebRequest)FtpWebRequest.Create($"{host}/{remoteFile}");
                request.Credentials = new NetworkCredential(user, pass);
                request.UseBinary = true;

                //2
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //3
                ftpStream = request.GetRequestStream();
                FileStream localFileStream = new FileStream(localFile, FileMode.Create);

                byte[] byteBuff = new byte[buffSize];
                int bytesSent = localFileStream.Read(byteBuff, 0, buffSize);

                try
                {
                    while (bytesSent > 0)
                    {
                        ftpStream.Write(byteBuff, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuff, 0, buffSize);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n> Copy Exception: {ex.Message}");
                }

                localFileStream.Close();
                ftpStream.Close();
                request = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n> Upload Exception: {ex.Message}");
            }
        }

        public void Delete(string remoteFile)
        {

        }

        public void DeleteDir(string remoteDir)
        {

        }

        public void Rename(string currentName, string newName)
        {

        }

        public void CreateDir(string newDir)
        {

        }
        public void GetCreateInfo(string remoteFile)
        {

        }
        public void GetSizeInfo(string remoteFile)
        {

        }
        public void GetDirList(string remoteDir)
        {

        }

        public void GetListDetails(string remoteDir)
        {

        }
    }
}
