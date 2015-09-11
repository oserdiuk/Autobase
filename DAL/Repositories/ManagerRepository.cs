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
    public class ManagerRepository : IRepository<Manager>
    {
        private MotorDepotDbContext dbContext;

        public ManagerRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Manager> GetAll()
        {
            return dbContext.Managers;
        }

        public Manager Get(int id)
        {
            return dbContext.Managers.Find(id);
        }

        public void Create(Manager item)
        {
            dbContext.Managers.Add(item);
        }

        public void Update(Manager item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Manager manager = dbContext.Managers.Find(id);
            if (manager != null)
                dbContext.Managers.Remove(manager);
        }
    }
}
