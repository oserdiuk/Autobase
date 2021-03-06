﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class DrivingLicense
    {
        public int DrivingLicenseId { get; set; }
        public int DrivingLicenseTypeId { get; set; }
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual DrivingLicenseType DrivingLicenseType { get; set; }

        public DrivingLicense()
        {

        }

        public DrivingLicense(int licenseTypeId, int driverId)
        {
            this.DrivingLicenseTypeId = licenseTypeId;
            this.DriverId = driverId;
        }
    }
}
