using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.EntitiesToTransfer
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<RouteStatus> RouteStatuses { get; set; }
    }
}
