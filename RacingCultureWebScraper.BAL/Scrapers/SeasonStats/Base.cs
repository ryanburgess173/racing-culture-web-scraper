using RacingCultureWebScraper.BAL.Models;
using RacingCultureWebScraper.BAL.Models.SeasonStats;
using System.Configuration;
using System.Net;

namespace RacingCultureWebScraper.BAL.Scrapers.SeasonStats
{
    internal class Base
    {
        public SeasonStatsBase seasonStats { get; set; }
        public int yearToScrape { get; set; }
        public Division divisionToScrape { get; set; }
        private string urlBase { get; set; }
        private string SeasonStatsUrlModifier { get; set; }

        public Base(int year, Division division)
        {
            this.SeasonStatsUrlModifier = "/season-stats";
            this.seasonStats = new SeasonStatsBase();
            this.yearToScrape = year;
            this.divisionToScrape = division;
            this.urlBase = ConfigurationManager.AppSettings["scrapingUrlBase"] ?? "";
            string requestUrl = GenerateUrl();
            if (requestUrl[0] == '/')
            {
                throw InvalidUrlException(requestUrl);
            }
            else
            {
                HttpResponseMessage response = GETRequest(requestUrl).Result;
            }
        }

        private string GenerateUrl()
        {
            string finalUrl = this.urlBase;
            finalUrl += this.SeasonStatsUrlModifier;
            finalUrl += "/" + this.yearToScrape.ToString();
            switch (this.divisionToScrape.Name)
            {
                case "NASCAR Sprint Cup Series":
                case "NASCAR Cup Series":
                    finalUrl += "/W/";
                    break;
                case "NASCAR XFinity Series":
                case "NASCAR Busch Series":
                    finalUrl += "/B/";
                    break;
                default:
                    finalUrl += "/W/";
                    break;
            }
            return finalUrl;
        }

        private async Task<HttpResponseMessage> GETRequest(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync(fullUrl);
            return response;
        }

        private Exception InvalidUrlException(string requestUrl)
        {
            Console.WriteLine("Url Invalid.");
            Console.WriteLine(requestUrl);
            throw new NotImplementedException();
        }
    }
}
