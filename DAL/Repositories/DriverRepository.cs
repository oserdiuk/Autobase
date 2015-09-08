using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DriverRepository : IRepository<Driver>
    {
        private MotorDepotDbContext dbContext;

        public DriverRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Driver> GetAll()
        {
            return dbContext.Drivers;
        }

        public Driver Get(int id)
        {
            return dbContext.Drivers.Find(id);
        }

        public void Create(Driver item)
        {
            dbContext.Drivers.Add(item);
        }

        public void Update(Driver item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Driver driver = dbContext.Drivers.Find(id);
            if (driver != null)
                dbContext.Drivers.Remove(driver);
        }
    }
}
