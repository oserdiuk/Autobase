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
    public class DrivingLicenseTypeRepository : IRepository<DrivingLicenseType>
    {
        private MotorDepotDbContext dbContext;

        public DrivingLicenseTypeRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DrivingLicenseType> GetAll()
        {
            return dbContext.DrivingLicenseTypes;
        }

        public DrivingLicenseType Get(int id)
        {
            return dbContext.DrivingLicenseTypes.Find(id);
        }

        public void Create(DrivingLicenseType item)
        {
            dbContext.DrivingLicenseTypes.Add(item);
        }

        public void Update(DrivingLicenseType item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DrivingLicenseType drivingLicenseType = dbContext.DrivingLicenseTypes.Find(id);
            if (drivingLicenseType != null)
                dbContext.DrivingLicenseTypes.Remove(drivingLicenseType);
        }
    }
}
