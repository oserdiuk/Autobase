using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class MotorDepotDbContext : DbContext
    {
        public MotorDepotDbContext()
            : base("MotorDepotDbContext") { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DrivingLicense> DrivingLicenses { get; set; }
        public DbSet<DrivingLicenseType> DrivingLicenseTypes { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteStatus> RouteStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SiteException> SiteExceptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
