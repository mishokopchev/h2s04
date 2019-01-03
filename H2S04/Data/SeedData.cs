using System;
using System.Threading.Tasks;
using H2S04.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace H2S04.Data
{
    public class SeedData
    {
        public SeedData()
        {

        }

        public static async void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new UserContext(serviceProvider.GetRequiredService<DbContextOptions<UserContext>>()))
            //{
                var testUserPw = "IntelpenKur@123";
                var adminID = await EnsureUser(serviceProvider,"admin@abv.bg",testUserPw);
                await EnsureRole(serviceProvider, adminID, Constants.ProductAdministratorsRole);

                // allowed user can create and edit contacts that they create
                //var managerID = await EnsureUser(serviceProvider,"manager@abv.bg", testUserPw);
                //await EnsureRole(serviceProvider, managerID, Constants.ProductManagersRole);
            //}

            Console.WriteLine(2);
        }

        public static async Task<string> EnsureUser(IServiceProvider ServiceProvider,string Username,string Password)
        {
            var userManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(Username);

            if(user == null)
            {
                user = new ApplicationUser { UserName = Username };
                var result = await userManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {

                }


            }

            return user.Id;
        }

        public static async Task<IdentityResult> EnsureRole(IServiceProvider ServiceProvider,string Id,string Role) 
        {
            var userManager = ServiceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(Id);

            IdentityResult IR = null;
            var roleManager = ServiceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager is null");
            }

            if (!await roleManager.RoleExistsAsync(Role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole { Name = Role });
            }

            IR = await userManager.AddToRoleAsync(user, Role);

            return IR;
        }


    }
}
