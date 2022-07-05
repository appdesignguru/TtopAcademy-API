using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TtopAcademy.API.Models;

[assembly: OwinStartup(typeof(TtopAcademy.API.Startup))]

namespace TtopAcademy.API
{
    /// <summary> Startup class. </summary>
    public partial class Startup
    {
        /// <summary> Configures the app. </summary>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (roleManager.RoleExists("Adminstrator"))
            {
                return;
            }

            // Create Role
            roleManager.Create(new IdentityRole { Name = "Adminstrator" });

            string email = ReadSetting("adminEmail");
            string password = ReadSetting("adminPassword");

            if (email == null || password == null)
            {
                return;
            }

            var user = new ApplicationUser {
                UserName = email, Email = email,
            };

            var createdUser = userManager.Create(user, password);

            if (createdUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "Adminstrator");
            }
        }

        private string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine(key + result);
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return null;
            }
        }
    }
}
