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
        private UserRepository userRepository;

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
