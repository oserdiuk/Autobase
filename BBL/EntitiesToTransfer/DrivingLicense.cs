using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.EntitiesToTransfer
{
    public class DrivingLicense
    {
        public int DrivingLicenseId { get; set; }
        public int DrivingLicenseTypeId { get; set; }
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual DrivingLicenseType DrivingLicenseType { get; set; }
    }
}
