using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITrellisCarDealershipAPI.Models
{
    public class Car
    {
        public Car() { }
        public Car(string id, string make, short year, string color, int miles, int price, bool hasSunroof, bool isFourWheelDrive, bool hasPowerWindows, bool hasNavigation, bool hasHeatedSeats)
        {
            _id = id;
            this.make = make;
            this.year = year;
            this.color = color;
            this.miles = miles;
            this.price = price;
            this.hasSunroof = hasSunroof;
            this.isFourWheelDrive = isFourWheelDrive;
            this.hasPowerWindows = hasPowerWindows;
            this.hasNavigation = hasNavigation;
            this.hasHeatedSeats = hasHeatedSeats;
        }

        [Key]
        public string _id { get; set; }
        public string make { get; set; }
        public Int16 year { get; set; }
        public string color { get; set; }
        public int miles { get; set; }
        public int price { get; set; }
        public bool hasSunroof { get; set; }
        public bool isFourWheelDrive { get; set; }
        public bool hasPowerWindows { get; set; }
        public bool hasNavigation { get; set; }
        public bool hasHeatedSeats { get; set; }
    }
}
