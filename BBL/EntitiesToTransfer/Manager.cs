using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.EntitiesToTransfer
{
    public class Manager : IUser
    {
        public int ManagerId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
