namespace RacingCultureWebScraper.BAL.Models
{
    public class Division
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Division(int iD, string name)
        {
            ID = iD;
            Name = name;
        }   
    }
}
