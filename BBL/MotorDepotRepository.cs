using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBl
{
    public class MotorDepotRepository : IMotorDepotRepository
    {
        private MotorDepotDbContext dbContext;
        private MotorDepotDbContext DbContext
        {
            get
            {
                if (dbContext == null)
                {
                    dbContext = new MotorDepotDbContext();
                }

                return dbContext;
            }
        }

        public int GetUserById(int id)
        {
            return 5;
        }
    }
}
