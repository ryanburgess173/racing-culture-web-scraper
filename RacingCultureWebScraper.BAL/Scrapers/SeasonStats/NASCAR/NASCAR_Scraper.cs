
namespace RacingCultureWebScraper.BAL.Scrapers.SeasonStats.NASCAR
{
    internal class NASCAR_Scraper : Base_SeasonStats_Scraper
    {
        public NASCAR_Scraper(int year, char division) : base(year, division){
            this.SetFieldsToScrape();
            var data = this.ParseHtml();
            foreach(var row in data)
            {
                foreach(var cell in row)
                {
                    Console.Write(cell.InnerText + "\n");
                }
                Console.Write("\n");
            }
        }

        public List<List<HtmlAgilityPack.HtmlNode>> ParseHtml()
        {
            List<List<HtmlAgilityPack.HtmlNode>> data = new List<List<HtmlAgilityPack.HtmlNode>>();
            for(var i=1; i<this.FieldsToScrape.Length; i++)
            {
                List<HtmlAgilityPack.HtmlNode> listOfFieldNodes = this.loadedHtmlDocument.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Contains(this.FieldsToScrape[i]))
                    .ToList();
                data.Add(listOfFieldNodes);
            }
            return data;
        }

        public override void SetFieldsToScrape()
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
                "purse",
                "pole",
                "cautions",
                "laps",
                "speed",
                "lc"
            };
        }
    }
}
