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
            this.RouteRepository.GetAll().Where(route => route.DepartureDate < DateTime.Now).ToList<Route>()
                .ForEach(route => route.RouteStatusId = statuses
                    .Where(s => s.StatusName.ToLower().Contains("выполняется")).FirstOrDefault().RouteStatusId);

            this.RouteRepository.GetAll().Where(route => route.ArrivalDate < DateTime.Now).ToList<Route>()
                .ForEach(route =>
                {
                    route.RouteStatusId = statuses
                        .Where(s => s.StatusName.ToLower().Contains("выполнен")).FirstOrDefault().RouteStatusId;
                    FreeCar(route.CarId);
                }
            );
            this.Save();
        }

        private void FreeCar(int carId)
        {
            this.CarRepository.Get(carId).IsBusy = false;
        }

        public void Save()
        {
            dbContext.SaveChanges();
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
