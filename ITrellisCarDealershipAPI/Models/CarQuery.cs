using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITrellisCarDealershipAPI.Models
{
    public class CarQuery
    {
        public string Color { get; set; }
        public bool? HasSunroof { get; set; }
        public bool? IsFourWheelDrive { get; set; }
        public bool? HasLowMiles { get; set; }
        public bool? HasPowerWindows { get; set; }
        public bool? HasNavigation { get; set; }
        public bool? HasHeatedSeats { get; set; }
    }
}
