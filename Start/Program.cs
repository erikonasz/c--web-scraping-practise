using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Send get request to weather.com
            string url = "https://weather.com/lt-LT/orai/siandien/l/LHXX0005:1:LH?Goto=Redirected";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;

            // Use HtmlDocument type
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Fix typo in SelectSingleNode
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temperature);

            // Get conditions

            var conditionsElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var conditions = conditionsElement.InnerText.Trim();
            Console.WriteLine("Condition: " + conditions);

            // Get location

            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("Location: " + location);

            // Get alert about weather

            var alertElement = htmlDocument.DocumentNode.SelectSingleNode("//h2[@class='AlertHeadline--alertText--38xov']");
            var alert = alertElement.InnerText.Trim();
            Console.WriteLine("Alert: " + alert);

            // Air Quality

            var airqElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='AirQualityText--severity--W9CtX']");
            var airq = airqElement.InnerText.Trim();
            Console.WriteLine("Air Quality: " + airq);
        }
    }
}