using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCultureWebScraper.BAL.Models
{
    public class Track
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int YearOfConstruction { get; set; }
        public int Capacity { get; set; }
    }
}
