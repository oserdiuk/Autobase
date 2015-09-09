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
    public class UserRepository : IRepository<User>
    {
        private MotorDepotDbContext dbContext;

        public UserRepository(MotorDepotDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.Users;
        }

        public User Get(int id)
        {
            return dbContext.Users.Find(id);
        }

        public void Create(User item)
        {
            dbContext.Users.Add(item);
        }

        public void Update(User item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = dbContext.Users.Find(id);
            if (user != null)
                dbContext.Users.Remove(user);
        }
    }
}
