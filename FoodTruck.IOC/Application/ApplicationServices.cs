using Microsoft.Extensions.DependencyInjection;

namespace FoodTruck.IOC.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
