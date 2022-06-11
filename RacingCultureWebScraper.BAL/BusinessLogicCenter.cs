using RacingCultureWebScraper.BAL.Scrapers.SeasonStats;
using RacingCultureWebScraper.BAL.Scrapers.SeasonStats.Formula;
using RacingCultureWebScraper.BAL.Scrapers.SeasonStats.NASCAR;

namespace RacingCultureWebScraper.BAL
{
    public class BusinessLogicCenter
    {
        public Base_SeasonStats_Scraper scraper { get; set; }
        public BusinessLogicCenter(int year, string division, string dataSourceType)
        {
            switch (dataSourceType)
            {
                case "SeasonStats":
                    SeasonStatsScrapers(year, division);
                    break;
                case "RaceStats":
                    break;
            }
        }
        private void SeasonStatsScrapers(int year, string division)
        {
            char divisionModifier = FindDivisionModifier(division);
            switch (divisionModifier)
            {
                case 'W':
                case 'B':
                    this.scraper = new NASCAR_Scraper(year, divisionModifier);
                    return;
                case 'F':
                    this.scraper = new F1_Scraper(year, divisionModifier);
                    return;
            }
        }
        public char FindDivisionModifier(string division)
        {
            switch (division)
            {
                case "NASCAR Cup Series":
                    return 'W';
                case "NASCAR Busch Series":
                    return 'B';
                case "Formula 1":
                    return 'F';
            }
            return '_';
        }
    }
}
