using DAL;
using DAL.Abstract;
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

        public void CreateRoute(Route route, bool userInRoleDriver)
        {
            route.CreatingDate = DateTime.Now;
            route.RouteStatusId = this.repository.GetWaitingForDepartStatusId();
            if (userInRoleDriver)
            {
                route.RouteStatusId = this.repository.GetWaitingForConfirmStatusId();
            }
            this.repository.RouteRepository.Create(route);
            this.repository.Save();
        }

        public void EditRoute(Route route)
        {
            route.RouteStatusId = 1;
            this.repository.RouteRepository.Update(route);
            this.repository.Save();
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

        public List<Driver> GetAllDrivers()
        {
            return this.repository.DriverRepository.GetAll().ToList<Driver>();
        }

        public void CreateManager()
        {
            int userId = repository.UserRepository.GetAll().LastOrDefault().UserId;
            this.repository.ManagerRepository.Create(new Manager(userId));
            this.repository.Save();
        }

        public void DeleteRoute(int id)
        {
            this.repository.RouteRepository.Delete(id);
            this.repository.Save();
        }

        public bool CheckRouteForActive(int id)
        {
            int doneStatuseId = this.repository.GetInProgressStatusId();
            return this.repository.RouteRepository.Get(id).RouteStatusId == doneStatuseId;
        }

        public void ConfirmRoute(int id)
        {
            this.repository.RouteRepository.Get(id).RouteStatusId = this.repository.GetWaitingForDepartStatusId();
            this.repository.Save();
        }

        public bool CheckCarForActive(int id)
        {
            Car car = this.GetCar(id);
            foreach (var route in car.Routes)
            {
                if (CheckRouteForActive(route.RouteId))
                {
                    return true;
                }
            }
            return false;
        }

        public void ChangeRouteStatus(Route route, Car car)
        {
            this.repository.RouteRepository.Update(route);
            this.repository.CarRepository.Update(route.Car);
            this.repository.Save();
        }

        public void DeleteCar(int id)
        {
            this.repository.CarRepository.Delete(id);
            this.repository.Save();
        }

        public List<Route> GetRoutes(int sortTypeId = 0)
        {
            var routes = this.repository.RouteRepository.GetAll();
            switch ((SortRoute)sortTypeId)
            {
                case SortRoute.CreatingDateAsc:
                    return routes.OrderBy(route => route.CreatingDate).ToList<Route>();
                case SortRoute.CreatingDateDesc:
                    return routes.OrderBy(route => route.CreatingDate).Reverse().ToList<Route>();
                case SortRoute.RouteIdAsc:
                    return routes.OrderBy(route => route.RouteId).ToList<Route>();
                case SortRoute.RouteIdDesc:
                    return routes.OrderBy(route => route.RouteId).Reverse().ToList<Route>();
                case SortRoute.Status:
                    return routes.OrderBy(route => route.RouteStatusId).ToList<Route>();
                default: return routes.ToList<Route>();
            }
        }

        public List<Driver> GetDrivers()
        {
            return this.repository.DriverRepository.GetAll().Where(driver => !driver.User.IsDeleted).ToList<Driver>();
        }

        public List<Manager> GetManagers()
        {
            return this.repository.ManagerRepository.GetAll().Where(manager => !manager.User.IsDeleted).ToList<Manager>();
        }
    }
}
