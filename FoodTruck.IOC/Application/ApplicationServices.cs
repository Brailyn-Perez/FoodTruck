using FluentValidation;
using FoodTruck.Core.Application.Assemblyes;
using FoodTruck.Core.Application.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FoodTruck.IOC.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region Application Services
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            #endregion
            return services;

        }
    }
}
