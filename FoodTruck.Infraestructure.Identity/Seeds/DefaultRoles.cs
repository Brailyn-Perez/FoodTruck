using FoodTruck.Core.Application.Enums;
using FoodTruck.Infraestructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodTruck.Infraestructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed Role
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

        }
    }
}
