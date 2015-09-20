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
    public class CarRepository : IRepository<Car>
    {
        private MotorDepotDbContext dbContext;

        public CarRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Car> GetAll()
        {
            return dbContext.Cars;
        }

        public Car Get(int id)
        {
            return dbContext.Cars.Find(id);
        }

        public void Create(Car item)
        {
            dbContext.Cars.Add(item);
        }

        public void Update(Car item)
        {
            var oldCar = dbContext.Cars.Find(item.CarId);
            oldCar = item;
            var r = dbContext.Cars.Find(item.CarId);
            //TODO edit editing cars and routes.
          //  dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Car car = dbContext.Cars.Find(id);
            if (car != null)
                dbContext.Cars.Remove(car);
        }
    }
}
