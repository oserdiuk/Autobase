using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Direction { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public int RouteStatusId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Car Car { get; set; }
        public virtual RouteStatus RouteStatus { get; set; }
    }
}
