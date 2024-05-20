using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WEatherPredictionForTomorrow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string KEY = "63b9af5202514b14821145422241605";
                const string URL = "https://api.weatherapi.com/v1/forecast.xml";

                Console.WriteLine("\n> Input the name of target city:");
                string cityName = Console.ReadLine();

                string apiEP = $"{URL}?key={KEY}&q={cityName}&days=2&api=no";
                WebClient webClient = new WebClient();

                byte[] response = webClient.DownloadData(apiEP);
                string xmlData = Encoding.UTF8.GetString(response);

                XDocument doc = XDocument.Parse(xmlData);
                XElement root = doc.Element("root");

                string targetDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                string targetTime1 = "09:00";
                string targetTime2 = "14:00";
                string targetTime3 = "19:00";

                XElement forecastDay = root.Element("forecast")
                                           .Elements("forecastday")
                                           .FirstOrDefault(fd => fd.Element("date").Value == targetDate);

                if (forecastDay != null)
                {
                    XElement hourForecast1 = forecastDay.Descendants("hour")
                                                       .FirstOrDefault(h => h.Element("time").Value.Contains($" {targetTime1}"));
                    XElement hourForecast2 = forecastDay.Descendants("hour")
                                                       .FirstOrDefault(h => h.Element("time").Value.Contains($" {targetTime2}"));
                    XElement hourForecast3 = forecastDay.Descendants("hour")
                                                       .FirstOrDefault(h => h.Element("time").Value.Contains($" {targetTime3}"));

                    if (hourForecast1 != null && hourForecast2 != null && hourForecast3 != null)
                    {
                        string temp1C = hourForecast1.Element("temp_c").Value;
                        string temp2C = hourForecast2.Element("temp_c").Value;
                        string temp3C = hourForecast3.Element("temp_c").Value;

                        Console.WriteLine($"Forecast for {targetDate} in {cityName}\n" +
                            $"At {targetTime1} : {temp1C}°C\n" +
                            $"At {targetTime2} : {temp2C}°C\n" +
                            $"At {targetTime3} : {temp3C}°C");
                    }
                    else
                    {
                        Console.WriteLine("Forecast for the specified time not found.");
                    }
                }
                else
                {

                    Console.WriteLine("Forecastday null.");
                }
            }
            catch (Exception ex)
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
