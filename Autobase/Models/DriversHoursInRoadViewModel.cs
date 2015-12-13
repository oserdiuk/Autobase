using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobase.Models
{
    public class DriversHoursInRoadViewModel
    {
        public int DriverId { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverSecondName { get; set; }
        public Dictionary<string, long> DriverDirectionsHours { get; set; }
        public Dictionary<string, long> DriverCarsHours { get; set; }
        public TimeSpan AllHoursInRoad { get; set; }
    }
}