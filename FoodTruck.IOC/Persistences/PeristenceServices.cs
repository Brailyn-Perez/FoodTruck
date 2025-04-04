using FoodTruck.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodTruck.IOC.Persistences
{
    public static class PeristenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            if (!configuration.GetValue<bool>("InMemory"))
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("FoodTruckDB"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseInMemoryDatabase("FoodTruckDB"));
            }

            return services;
        }
    }
}
