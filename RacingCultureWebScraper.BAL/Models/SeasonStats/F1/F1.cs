using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCultureWebScraper.BAL.Models.SeasonStats.F1
{
    internal class F1
    {
        public int Laps { get; set; }
        public F1(int laps) : base()
        {
            this.Laps = laps;
        }
    }
}
