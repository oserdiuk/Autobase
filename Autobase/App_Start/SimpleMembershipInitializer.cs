using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace Autobase.App_Start
{
    public class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {
            using (MotorDepotDbContext dbContext = new MotorDepotDbContext())
            {
                dbContext.Database.CreateIfNotExists();

                WebSecurity.InitializeDatabaseConnection("MotorDepotDbContext", "User", "UserId", "Email", autoCreateTables: true);
                SimpleRoleProvider roles = (SimpleRoleProvider)Roles.Provider;
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MotorDepotDbContext>());
                SimpleMembershipProvider membership = (SimpleMembershipProvider)Membership.Provider;

                if (!roles.RoleExists("Admin"))
                {
                    roles.CreateRole("Admin");
                }

                if (!roles.RoleExists("Driver"))
                {
                    roles.CreateRole("Driver");
                }

                if (!roles.RoleExists("Manager"))
                {
                    roles.CreateRole("Manager");
                }

                User userAdmin = new User()
                {
                    Email = "admin@mail.com",
                    FirstName = "Оксана",
                    SecondName = "Сердюк",
                    BirthDate = new DateTime(1996, 8, 31),
                    Address = "Целиноградская, 36",
                    City = "Харьков",
                    Phone = "+380508500243",
                    EmploymentDate = new DateTime(2015, 9, 6),
                    IsDeleted = false
                };

                if (membership.GetUser("admin@mail.com", false) == null)
                {
                    WebSecurity.CreateUserAndAccount(userAdmin.Email, "qwerty123", new
                    {
                        Email = userAdmin.Email,
                        FirstName = userAdmin.FirstName,
                        SecondName = userAdmin.SecondName,
                        BirthDate = userAdmin.BirthDate,
                        Address = userAdmin.Address,
                        City = userAdmin.City,
                        Phone = userAdmin.Phone,
                        EmploymentDate = userAdmin.EmploymentDate,
                        IsDeleted = userAdmin.IsDeleted
                    });

                    roles.AddUsersToRoles(new[] { "admin@mail.com" }, new[] { "Admin" });
                }
            }
        }
    }
}