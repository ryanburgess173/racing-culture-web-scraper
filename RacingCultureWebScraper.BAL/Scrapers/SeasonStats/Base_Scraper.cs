using HtmlAgilityPack;
using RacingCultureWebScraper.BAL.Models.SeasonStats;
using System.Configuration;
using System.Net;

namespace RacingCultureWebScraper.BAL.Scrapers.SeasonStats
{
    internal class Base_Scraper
    {
        public SeasonStatsBase seasonStats { get; set; }
        private string urlBase { get; set; }
        private int yearToScrape { get; set; }
        private char divisionToScrape { get; set; }
        private string SeasonStatsUrlModifier { get; set; }
        public HtmlDocument loadedHtmlDocument { get; set; }

        public Base_Scraper(int year, char divisionModifier)
        {
            this.SeasonStatsUrlModifier = "/season-stats";
            this.seasonStats = new SeasonStatsBase();
            this.urlBase = ConfigurationManager.AppSettings["scrapingUrlBase"] ?? "";
            this.yearToScrape = year;
            this.divisionToScrape = divisionModifier;
            string requestUrl = GenerateRequestUrl();
            string responseString = GETRequest(requestUrl).Result;
            this.loadedHtmlDocument = ParseResponse(responseString);
        }

        private HtmlDocument ParseResponse(string response)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(response);
            return htmlDocument;
        }

        private string GenerateRequestUrl()
        {
            return this.urlBase 
                + this.SeasonStatsUrlModifier 
                + "/" + this.yearToScrape.ToString() 
                + "/" + this.divisionToScrape.ToString() + "/";
        }

        private async Task<string> GETRequest(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            string response = await client.GetStringAsync(fullUrl);
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
