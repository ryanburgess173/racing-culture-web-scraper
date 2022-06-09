using RacingCultureWebScraper.BAL.Models;

namespace RacingCultureWebScraper.BAL.SeasonStats
{
    internal class Base
    {
        public int ID { get; set; }
        public DateOnly RaceDate { get; set; }
        public Track Track { get; set; }
        public int NumberOfCars { get; set; }
        public Driver Winner { get; set; }
        public int WinnerStartingSpot { get; set; }
        public Car WinningCar { get; set; }
        public int LengthOfRaceInLaps { get; set; }
        public char SurfaceType { get; set; }
        public int Miles { get; set; }
        public double PoleSpeed { get; set; }
        public double RaceSpeed { get; set; }
        public int LapsCompleted { get; set; }
        public Division Division { get; set; }
    }
}
