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
        }
    }
}