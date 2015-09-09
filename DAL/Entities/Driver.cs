using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Driver : IUser
    {
        public int DriverId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<DrivingLicense> DrivingLicenses { get; set; }

        public Driver()
        {

        }

        public Driver(int userId)
        {
            this.UserId = userId;
        }
    }
}
