namespace MVC.CMS.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVC.CMS.Models;
    using System;
    using System.Collections.Generic;
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
            var store = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(store);
            List<IdentityRole> identityRoles = new List<IdentityRole> {
                new IdentityRole { Name = RoleTypes.Admin },
                new IdentityRole { Name = RoleTypes.SuperUser },
                new IdentityRole { Name = RoleTypes.User }
            };
            foreach (IdentityRole role in identityRoles) {
                roleManager.Create(role);
            }

            

            var passwordHasher = new PasswordHasher();
            
            if (!context.Users.Any(u => u.UserName == "admin@admin.com")) {
                string admUser = "admin@admin.com";
                string hashedPassword = passwordHasher.HashPassword("Password@123");
                var admin = new ApplicationUser {
                    UserName = admUser,
                    PasswordHash = hashedPassword,
                    PhoneNumber = "12345678911",
                    Country = 1,
                    City = "Malmö",
                    Email = "admin@admin.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                context.Users.AddOrUpdate(x => x.UserName, admin);
                context.SaveChanges();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                

                

                var adminUser = userManager.FindByName(admUser);
                userManager.AddToRole(adminUser.Id, RoleTypes.Admin);
            }


            var users = new List<ApplicationUser> {
                new ApplicationUser() {
                    UserName = "a@b.com",
                    PasswordHash = passwordHasher.HashPassword("Password@1"),
                    PhoneNumber = "12345678911",
                    Country = 1,
                    City = "Malmö",
                    Email = "a@b.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser() {
                    UserName = "b@c.com",
                    PasswordHash = passwordHasher.HashPassword("Password@2"),
                    PhoneNumber = "12345678911",
                    Country = 1,
                    City = "Malmö",
                    Email = "b@c.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser() {
                    UserName = "c@d.com",
                    PasswordHash = passwordHasher.HashPassword("Password@3"),
                    PhoneNumber = "12345678911",
                    Country = 1,
                    City = "Malmö",
                    Email = "c@d.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };
            users.ForEach(s => context.Users.AddOrUpdate(x => x.UserName, s));

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Users.AddOrUpdate(u => u.UserName, new ApplicationUser {
            //    UserName = "admin@admin.com",
            //    PasswordHash = hashedPassword,
            //    PhoneNumber = "12345678911",
            //    Country = 1,
            //    City = "Malmö",
            //    Email = "admin@admin.com",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //});
        }
    }
}
