using HtmlAgilityPack;
using RacingCultureWebScraper.BAL.Models.SeasonStats;
using System.Configuration;
using System.Net;

namespace RacingCultureWebScraper.BAL.Scrapers.SeasonStats
{
    public abstract class Base_SeasonStats_Scraper
    {
        public SeasonStatsBase seasonStats { get; set; }
        private string urlBase { get; set; }
        private int yearToScrape { get; set; }
        private char divisionToScrape { get; set; }
        private string seasonStatsUrlModifier { get; set; }
        public HtmlDocument loadedHtmlDocument { get; set; }
        public string[] FieldsToScrape { get; set; }

        public Base_SeasonStats_Scraper(int year, char divisionModifier)
        {
            this.seasonStatsUrlModifier = "/season-stats";
            this.seasonStats = new SeasonStatsBase();
            var appSettings = ConfigurationManager.AppSettings;
            this.urlBase = ConfigurationManager.AppSettings["scrapingUrlBase"] ?? "";
            this.yearToScrape = year;
            this.divisionToScrape = divisionModifier;
            string requestUrl = GenerateRequestUrl();
            string responseString = GETRequest(requestUrl).Result;
            this.loadedHtmlDocument = ParseResponse(responseString);
        }

        public virtual void SetFieldsToScrape()
        {
            this.FieldsToScrape = new string[] {
                "date",
                "track",
                "cars",
                "winners",
                "laps",
                "st",
                "manufacturer",
                "len",
                "sfc",
                "miles",
                "pole",
                "speed",
                "lc"
            };
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
                + this.seasonStatsUrlModifier 
                + "/" + this.yearToScrape.ToString() 
                + "/" + this.divisionToScrape.ToString() + "/";
        }

        private async Task<string> GETRequest(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            string response;
            try { 
                response = await client.GetStringAsync(fullUrl); 
            }catch(AggregateException e){
                Console.WriteLine("Aggregate Exception - "+e.ToString());
                response = "AggregateException thrown. Likely a bad URL.";
            }
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
