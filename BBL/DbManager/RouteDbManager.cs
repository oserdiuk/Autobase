using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.DbManager
{
    public class RouteDbManager
    {
        GlobalRepository repository = new GlobalRepository();

        public List<DrivingLicenseType> GetDrivingLicenseTypes()
        {
            return repository.DrivingLicenseTypeRepository.GetAll().ToList<DrivingLicenseType>();
        }

        public void CreateDriverLicenses(List<string> selectedDriverLicenses)
        {
            int driverUserId = repository.UserRepository.GetAll().LastOrDefault().UserId;
            this.repository.DriverRepository.Create(new Driver(driverUserId));
            int driverId = repository.DriverRepository.GetAll().LastOrDefault().DriverId;

            foreach (var licenseId in selectedDriverLicenses)
            {
                this.repository.DrivingLicenseRepository.Create(new DrivingLicense(Convert.ToInt32(licenseId), driverId));
            }
            repository.Save();
        }
    }
}
