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

        public RouteDbManager()
        {
            repository.UpdateRouteStatuses();
        }

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

        public List<string> GetCarTypes()
        {
            return repository.DrivingLicenseTypeRepository.GetAll().Select(type => type.TransportType).ToList<string>();
        }

        public void CreateCar(Car car)
        {
            try
            {
                car.IsIntegral = true;
                this.repository.CarRepository.Create(car);
                this.repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Car> GetCarsFreeForRoute()
        {
            return this.repository.CarRepository.GetAll().Where(car => car.IsIntegral && !car.IsBusy).ToList<Car>();
        }

        public List<RouteStatus> GetRouteStatuses()
        {
            return this.repository.RouteStatusRepository.GetAll().ToList<RouteStatus>();
        }

        public void CreateRoute(Route route)
        {
            route.CreatingDate = DateTime.Now;
            this.repository.RouteRepository.Create(route);
            this.repository.CarRepository.Get(route.CarId).IsBusy = true;
            this.repository.Save();
        }

        public void EditRoute(Route route)
        {
            this.repository.RouteRepository.Update(route);
            this.repository.Save();
            this.repository.UpdateRouteStatuses();
        }

        public Route GetRoute(int id)
        {
            return this.repository.RouteRepository.Get(id);
        }

        public void EditCar(Car car)
        {
            this.repository.CarRepository.Update(car);
            this.repository.Save();
        }

        public Car GetCar(int id)
        {
            return this.repository.CarRepository.Get(id);
        }
    }
}
