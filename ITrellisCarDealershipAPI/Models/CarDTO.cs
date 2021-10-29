using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITrellisCarDealershipAPI.Models
{
    public class CarDTO
    {
        public string make { get; set; }
        public Int16 year { get; set; }
        public int miles { get; set; }
        public int price { get; set; }
        public string color { get; set; }
        public bool hasSunroof { get; set; }
        public bool isFourWheelDrive { get; set; }
        public bool hasPowerWindows { get; set; }
        public bool hasNavigation { get; set; }
        public bool hasHeatedSeats { get; set; }
    }
}
