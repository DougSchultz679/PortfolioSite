namespace PortfolioSite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PortfolioSite.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "vxpx17@gmail.com"))
            {
                userManager.Create(new ApplicationUser {
                    UserName = "vxpx17@gmail.com",
                    Email = "vxpx17@gmail.com",
                    FirstName = "Douglas",
                    LastName = "Schultz",
                    DisplayName = "DoWoSc"
                }, "Qwer!234");
                var UserID = userManager.FindByEmail("vxpx17@gmail.com").Id;
                userManager.AddToRole(UserID, "Admin");
            }
            
            if (!context.Users.Any(u => u.Email == "araynor@gmail.com"))
            {
                userManager.Create(new ApplicationUser {
                    UserName = "araynor@gmail.com",
                    Email = "araynor@gmail.com",
                    FirstName = "Antonio",
                    LastName = "Raynor",
                    DisplayName = "AnIvRa"
                }, "Qwer!234");
                var UserID = userManager.FindByEmail("araynor@gmail.com").Id;
                userManager.AddToRole(UserID, "Moderator");
            }
        }
    }
}
