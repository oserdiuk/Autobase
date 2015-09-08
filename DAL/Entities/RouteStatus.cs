using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RouteStatus
    {
        public int RouteStatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
