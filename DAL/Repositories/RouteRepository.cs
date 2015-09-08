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
    public class RouteRepository : IRepository<Route>
    {
        private MotorDepotDbContext dbContext;

        public RouteRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Route> GetAll()
        {
            return dbContext.Routes;
        }

        public Route Get(int id)
        {
            return dbContext.Routes.Find(id);
        }

        public void Create(Route item)
        {
            dbContext.Routes.Add(item);
        }

        public void Update(Route item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Route route = dbContext.Routes.Find(id);
            if (route != null)
                dbContext.Routes.Remove(route);
        }
    }
}
