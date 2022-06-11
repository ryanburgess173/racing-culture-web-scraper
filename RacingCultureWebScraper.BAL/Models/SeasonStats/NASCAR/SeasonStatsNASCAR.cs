
namespace RacingCultureWebScraper.BAL.Models.SeasonStats.NASCAR
{
    internal class SeasonStatsNASCAR : SeasonStatsBase
    {
        public int NumberOfCautions { get; set; }
        public int CautionLaps { get; set; }
        public SeasonStatsNASCAR(int numberOfCautions, int cautionLaps) : base()
        {
            this.NumberOfCautions = numberOfCautions;
            this.CautionLaps = cautionLaps;
        }
        public SeasonStatsNASCAR() { }
    }
}
