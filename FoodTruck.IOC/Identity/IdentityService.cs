using FoodTruck.Infraestructure.Identity.Contexts;
using FoodTruck.Infraestructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FoodTruck.IOC.Identity
{
    public static class IdentityService
    {
        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            // Otros servicios que necesitas, como JWT, etc.
        }
    }
}
