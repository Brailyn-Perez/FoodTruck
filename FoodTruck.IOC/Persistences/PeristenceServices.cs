using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Infraestructure.Persistence.Context;
using FoodTruck.Infraestructure.Persistence.Repositories;
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

            #region Repositories
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISaleDetailsRepository, SaleDetailRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion

            return services;
        }
    }
}
