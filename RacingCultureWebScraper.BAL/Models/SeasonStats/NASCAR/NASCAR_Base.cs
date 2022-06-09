using RacingCultureWebScraper.BAL.SeasonStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCultureWebScraper.BAL.Models.SeasonStats.NASCAR
{
    internal class NASCAR_Base : Base
    {
        public int NumberOfCautions { get; set; }
        public int CautionLaps { get; set; }
        public NASCAR_Base(int numberOfCautions, int cautionLaps) : base()
        {
            this.NumberOfCautions = numberOfCautions;
            this.CautionLaps = cautionLaps;
        }
    }
}
