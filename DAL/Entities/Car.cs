using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarNumber { get; set; }
        public string Model { get; set; }
        public int SeatingAccommodation { get; set; }
        public bool IsIntegral { get; set; }
        public bool IsBusy { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
