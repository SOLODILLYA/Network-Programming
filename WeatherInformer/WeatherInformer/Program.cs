using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;
using System.Data.Common;

namespace WeatherInformer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1
                const string KEY = "63b9af5202514b14821145422241605";
                const string URL = "https://api.weatherapi.com/v1/current.xml";

                // 2
                Console.WriteLine("\n> Input the name of target city:");
                string cityName = Console.ReadLine();

                // 3
                string apiEP = $"{URL}?key={KEY}&q={cityName}&api=no";
                WebClient webClient = new WebClient();

                // 4
                byte[] response = webClient.DownloadData(apiEP);
                string xmlData = Encoding.UTF8.GetString(response);

                //5
                XDocument doc = XDocument.Parse(xmlData);
                XElement root = doc.Element("root");

                //6
                string currentTempreture = root.Element("current").Element("temp_c").Value;
                Console.WriteLine($"\n> Current Tempreture in city: {cityName} is {currentTempreture} C");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }finally
            {
                Console.WriteLine("\n\nFinish");
            }
        }
    }
}
