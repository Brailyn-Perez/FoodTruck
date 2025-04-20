using FoodTruck.Core.Application.Enums;
using FoodTruck.Infraestructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodTruck.Infraestructure.Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public async static Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default admin User

            var defaultUser = new ApplicationUser
            {
                UserName = "UserAdmin",
                Email = "userAdmin@gmail.com",
                Name = "Brailyn",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "1234Password");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
                }
            }
        }
    }
}
