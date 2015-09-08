using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class DrivingLicenseType
    {
        public int DrivingLicenseTypeId { get; set; }
        public string Category { get; set; }
        public string TransportType { get; set; }

        public ICollection<DrivingLicense> DrivingLicenses { get; set; }
    }
}
