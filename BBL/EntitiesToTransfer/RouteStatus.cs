using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.EntitiesToTransfer
{
    public class RouteStatus
    {
        public int RouteStatusId { get; set; }
        public int StatusId { get; set; }
        public int RouteId { get; set; }

        public virtual Status Status { get; set; }
        public virtual Route Route { get; set; }
    }
}
