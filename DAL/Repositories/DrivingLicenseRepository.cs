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
    public class DrivingLicenseRepository : IRepository<DrivingLicense>
    {
        private MotorDepotDbContext dbContext;

        public DrivingLicenseRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DrivingLicense> GetAll()
        {
            return dbContext.DrivingLicenses;
        }

        public DrivingLicense Get(int id)
        {
            return dbContext.DrivingLicenses.Find(id);
        }

        public void Create(DrivingLicense item)
        {
            dbContext.DrivingLicenses.Add(item);
        }

        public void Update(DrivingLicense item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DrivingLicense drivingLicense = dbContext.DrivingLicenses.Find(id);
            if (drivingLicense != null)
                dbContext.DrivingLicenses.Remove(drivingLicense);
        }
    }
}
