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
    public class DbManager
    {
        GlobalRepository repository = new GlobalRepository();

        #region Routes
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
            this.repository.RouteRepository.Update(route);
            this.repository.Save();
        }

        public Route GetRoute(int id)
        {
            return this.repository.RouteRepository.Get(id);
        }

        public void DeleteRoute(int id)
        {
            this.repository.RouteRepository.Delete(id);
            this.repository.Save();
        }

        //Check if route is in progress
        public bool CheckRouteForActive(int id)
        {
            int doneStatuseId = this.repository.GetInProgressStatusId();
            return this.repository.RouteRepository.Get(id).RouteStatusId == doneStatuseId;
        }

        //Change status to waiting for depart after driver's route order
        public void ConfirmRoute(int id)
        {
            this.repository.RouteRepository.Get(id).RouteStatusId = this.repository.GetWaitingForDepartStatusId();
            this.repository.Save();
        }

        public void ChangeRouteStatus(Route route, Car car)
        {
            this.repository.RouteRepository.Update(route);
            this.repository.CarRepository.Update(route.Car);
            this.repository.Save();
        }

        //Get list of routes either sorted or not
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
        #endregion

        #region DrivingLicense
        //Add driver licenses from a list of selected ones
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

        //Get all existing license types
        public List<DrivingLicenseType> GetDrivingLicenseTypes()
        {
            return repository.DrivingLicenseTypeRepository.GetAll().ToList<DrivingLicenseType>();
        }
        #endregion

        #region Car
        public List<string> GetCarTypes()
        {
            return repository.DrivingLicenseTypeRepository.GetAll().Select(type => type.TransportType).ToList<string>();
        }

        public void CreateCar(Car car)
        {
            car.IsIntegral = true;
            this.repository.CarRepository.Create(car);
            this.repository.Save();
        }

        //Get cars which are not busy and are integral
        public List<Car> GetCarsFreeForRoute()
        {
            return this.repository.CarRepository.GetAll().Where(car => car.IsIntegral && !car.IsBusy).ToList<Car>();
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

        public void DeleteCar(int id)
        {
            this.repository.CarRepository.Delete(id);
            this.repository.Save();
        }

        public List<Car> GetAllCars()
        {
            return this.repository.CarRepository.GetAll().ToList<Car>();
        }
        #endregion

        #region Users
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

        public List<Driver> GetDrivers()
        {
            return this.repository.DriverRepository.GetAll().ToList<Driver>();
        }

        public List<Manager> GetManagers()
        {
            return this.repository.ManagerRepository.GetAll().ToList<Manager>();
        }

        public Driver GetDriver(int id)
        {
            return this.repository.DriverRepository.Get(id);
        }

        public Manager GetManager(int id)
        {
            return this.repository.ManagerRepository.Get(id);
        }

        public IUser GetUser(int id, RoleEnum role = RoleEnum.Admin)
        {
            IUser result = null;
            switch (role)
            {
                case RoleEnum.Driver:
                    result = this.GetDriver(id);
                    break;
                case RoleEnum.Manager:
                    result = this.GetManager(id);
                    break;
                default:
                    this.repository.UserRepository.Get(id);
                    break;
            }
            return result;
        }

        public void DeleteUser(int id)
        {
            this.repository.UserRepository.Delete(id);
            this.repository.Save();
        }

        public void UpdateUser(IUser user)
        {
            if (user is Driver)
            {
                this.repository.DriverRepository.Update(user as Driver);
            }
            else if (user is Manager)
            {
                this.repository.ManagerRepository.Update(user as Manager);
            }
            this.repository.Save();
        }
        #endregion

        //Log exception to database
        public void AddException(Exception exception)
        {
            var siteExeption = MapperManager.Map<Exception, SiteException>(exception);
            this.repository.SiteExceptionRepository.Create(siteExeption);
            this.repository.Save();
        }

        public int GetInProgressStatusId()
        {
            return this.repository.GetInProgressStatusId();
        }

        public int GetWaitingForConfirmStatusId()
        {
            return this.repository.GetWaitingForConfirmStatusId();
        }

        public void CancelRoutesOfDriver(int id)
        {
            var routes = this.repository.RouteRepository.GetAll()
                .Where(route => route.Driver.UserId == id 
                    && (route.RouteStatusId == this.GetWaitingForConfirmStatusId() 
                    || route.RouteStatusId == this.GetWaitingForDepartStatusId()));
            foreach (var route in routes)
            {
                route.RouteStatusId = this.GetCancelRouteStatusId();
            }
            this.repository.Save();
        }

        public int GetWaitingForDepartStatusId()
        {
            return this.repository.GetWaitingForDepartStatusId();
        }

        public int GetDoneStatusId()
        {
            return this.repository.GetDoneStatusId();
        }

        public int GetCancelRouteStatusId()
        {
            return this.repository.GetCancelRouteStatus();
        }

        public List<Driver> GetNotDeletedDrivers()
        {
            return this.GetDrivers().Where(d => !d.User.IsDeleted).ToList<Driver>();
        }

        public List<Manager> GetNotDeletedManagers()
        {
            return this.GetManagers().Where(d => !d.User.IsDeleted).ToList<Manager>();
        }

        public void GetInProgressRoutes(List<Driver> drivers)
        {
            drivers.ForEach(d =>
            {
                List<Route> routes = new List<Route>();
                routes.AddRange(d.Routes.Where(r => r.RouteStatusId == this.GetDoneStatusId()));
                d.Routes = routes;
            });
        }

        public static Dictionary<string, long> GetDriversCarsAndHours(Driver src)
        {
            Dictionary<string, long> result = new Dictionary<string, long>();
            long timeInRoad;
            foreach (var route in src.Routes)
            {
                timeInRoad = route.ArrivalDate.Ticks - route.DepartureDate.Ticks;
                if (result.ContainsKey(route.Car.CarNumber))
                {
                    result[route.Car.CarNumber] += timeInRoad;
                }
                else
                {
                    result.Add(route.Car.CarNumber, timeInRoad);
                }
            }
            return result;
        }

        public static Dictionary<string, long> GetDriversDirectionsAndHours(Driver src)
        {
            Dictionary<string, long> result = new Dictionary<string, long>();
            long timeInRoad;
            foreach (var route in src.Routes)
            {
                timeInRoad = route.ArrivalDate.Ticks - route.DepartureDate.Ticks;
                if (result.ContainsKey(route.Direction))
                {
                    result[route.Direction] += timeInRoad;
                }
                else
                {
                    result.Add(route.Direction, timeInRoad);
                }
            }
            return result;
        }
    }
}
