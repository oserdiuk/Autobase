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
    public class SiteExceptionRepository : IRepository<SiteException>
    {
        private MotorDepotDbContext dbContext;

        public SiteExceptionRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<SiteException> GetAll()
        {
            return dbContext.SiteExceptions;
        }

        public SiteException Get(int id)
        {
            return dbContext.SiteExceptions.Find(id);
        }

        public void Create(SiteException item)
        {
            dbContext.SiteExceptions.Add(item);
        }

        public void Update(SiteException item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            SiteException exception = dbContext.SiteExceptions.Find(id);
            if (exception != null)
                dbContext.SiteExceptions.Remove(exception);
        }
    }
}
