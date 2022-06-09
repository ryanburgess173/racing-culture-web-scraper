using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCultureWebScraper.BAL.Models
{
    public class Car
    {
        public int ID { get; set; }
        public Manufacturer ManufacturerName { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(int ID, Manufacturer manufacturer, string model, int year)
        {
            this.ID = ID;
            this.ManufacturerName = manufacturer;
            this.Model = model;
            this.Year = year;
        }
        public Car(int ID, Manufacturer manufacturer)
        {
            this.ID = ID;
            this.ManufacturerName = manufacturer;
        }
    }
}
