using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WeatherParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string URL = "https://ua.sinoptik.ua";
                WebClient webClient = new WebClient();
                byte[] response = webClient.DownloadData(URL);
                string content = Encoding.UTF8.GetString(response);

                //2
                string target1 = "<div class=\"min\">";
                string target2 = "<div class=\"max\">";
                int pos1 = content.IndexOf(target1);
                int pos2 = content.IndexOf(target2);

                //3
                string sub1 = content.Substring(pos1, 48);
                int limit11 = sub1.IndexOf("<span>") + 6;
                int limit12 = sub1.IndexOf("&deg;");
                string res1 = sub1.Substring(limit11,limit12 - limit11);

                //4
                string sub2 = content.Substring(pos2, 48);
                int limit21 = sub2.IndexOf("<span>") + 6;
                int limit22 = sub2.IndexOf("&deg;");
                string res2 = sub2.Substring(limit21, limit22 - limit21);

                //#
                Console.WriteLine($"\n> Weather Information in Your Location:\n {DateTime.Now}");
                //sinoptik checks for geolocation of the request, so it will be dependant on location

                Console.WriteLine($"  Minimum Tempreture:\n {res1}");
                Console.WriteLine($"  Maximum Tempreture:\n {res2}");
                Console.WriteLine($"  From: {URL}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\n\nFinish");
            }
        }
    }
}
