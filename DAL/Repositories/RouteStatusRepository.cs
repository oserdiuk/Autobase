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
    public class RouteStatusRepository : IRepository<RouteStatus>
    {
        private MotorDepotDbContext dbContext;

        public RouteStatusRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<RouteStatus> GetAll()
        {
            return dbContext.RouteStatuses.ToList();
        }

        public RouteStatus Get(int id)
        {
            return dbContext.RouteStatuses.Find(id);
        }

        public void Create(RouteStatus item)
        {
            dbContext.RouteStatuses.Add(item);
        }

        public void Update(RouteStatus item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            RouteStatus routeStatus = dbContext.RouteStatuses.Find(id);
            if (routeStatus != null)
                dbContext.RouteStatuses.Remove(routeStatus);
        }
    }
}
