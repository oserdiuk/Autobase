using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GlobalRepository : IDisposable
    {
        private MotorDepotDbContext dbContext = new MotorDepotDbContext();

        private CarRepository carRepository;
        private RouteRepository routeRepository;
        private RouteStatusRepository routeStatusRepository;
        private ManagerRepository managerRepository;
        private UserRepository userRepository;
        private DrivingLicenseRepository drivingLicenseRepository;
        private DriverRepository driverRepository;
        private DrivingLicenseTypeRepository drivingLicenseTypeRepository;

        public DrivingLicenseTypeRepository DrivingLicenseTypeRepository
        {
            get
            {
                if (drivingLicenseTypeRepository == null)
                {
                    drivingLicenseTypeRepository = new DrivingLicenseTypeRepository(dbContext);
                }
                return drivingLicenseTypeRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(dbContext);
                }
                return userRepository;
            }
        }

        public CarRepository CarRepository
        {
            get
            {
                if (carRepository == null)
                {
                    carRepository = new CarRepository(dbContext);
                }
                return carRepository;
            }
        }

        public RouteStatusRepository RouteStatusRepository
        {
            get
            {
                if (routeStatusRepository == null)
                {
                    routeStatusRepository = new RouteStatusRepository(dbContext);
                }
                return routeStatusRepository;
            }
        }

        public ManagerRepository ManagerRepository
        {
            get
            {
                if (managerRepository == null)
                {
                    managerRepository = new ManagerRepository(dbContext);
                }
                return managerRepository;
            }
        }

        public RouteRepository RouteRepository
        {
            get
            {
                if (routeRepository == null)
                {
                    routeRepository = new RouteRepository(dbContext);
                }
                return routeRepository;
            }
        }

        public DrivingLicenseRepository DrivingLicenseRepository
        {
            get
            {
                if (drivingLicenseRepository == null)
                {
                    drivingLicenseRepository = new DrivingLicenseRepository(dbContext);
                }
                return drivingLicenseRepository;
            }
        }

        public DriverRepository DriverRepository
        {
            get
            {
                if (driverRepository == null)
                {
                    driverRepository = new DriverRepository(dbContext);
                }
                return driverRepository;
            }
        }

        public void UpdateRouteStatuses()
        {
            var statuses = this.RouteStatusRepository.GetAll();
            var inProgressId = statuses
                    .Where(s => s.StatusName.ToLower().Contains("выполняется")).FirstOrDefault().RouteStatusId;
            var doneId = statuses
                        .Where(s => s.StatusName.ToLower().Contains("выполнен")).FirstOrDefault().RouteStatusId;

            var routes = this.RouteRepository.GetAll();
            routes.Where(route => route.DepartureDate < DateTime.Now).ToList<Route>()
                .ForEach(route => route.RouteStatusId = inProgressId);

            routes.Where(route => route.ArrivalDate < DateTime.Now).ToList<Route>()
                .ForEach(route =>
                {
                    route.RouteStatusId = doneId;
                    FreeCar(route.CarId);
                }
            );

            this.CarRepository.GetAll().ToList<Car>().ForEach(car =>
            {
                if (car.Routes.Where(route => route.DepartureDate < DateTime.Now).FirstOrDefault() != null)
                {
                    if (car.Routes.Where(route => route.ArrivalDate < DateTime.Now).FirstOrDefault() != null)
                    {
                        car.IsBusy = false;
                    }
                    else
                    {
                        car.IsBusy = true;
                    }
                }
            });
            dbContext.SaveChanges();
        }

        private void FreeCar(int carId)
        {
            this.CarRepository.Get(carId).IsBusy = false;
        }

        public void Save()
        {
            UpdateRouteStatuses();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
