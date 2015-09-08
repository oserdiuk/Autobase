using DAL;
using System;
using System.Collections.Generic;
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
            try
            {
                using (MotorDepotDbContext dbContext = new MotorDepotDbContext())
                {
                    dbContext.Database.CreateIfNotExists();

                    WebSecurity.InitializeDatabaseConnection("MotorDepotDbContext", "User", "UserId", "Email", autoCreateTables: true);
                    SimpleRoleProvider roles = (SimpleRoleProvider)Roles.Provider;

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

                    if (membership.GetUser("admin", false) == null)
                    {
                        WebSecurity.CreateUserAndAccount("admin", "qwerty123", new
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
                        });

                        roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}