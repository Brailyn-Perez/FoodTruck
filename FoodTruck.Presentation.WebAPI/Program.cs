using FoodTruck.Infraestructure.Identity.Models;
using FoodTruck.Infraestructure.Identity.Seeds;
using FoodTruck.IOC.Application;
using FoodTruck.IOC.Identity;
using FoodTruck.IOC.Persistences;
using FoodTruck.Presentation.WebAPI.Extensions;
using Microsoft.AspNetCore.Identity;

namespace FoodTruck.Presentation.WebAPI
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //aplication services
            builder.Services.AddApplicationServices();
            //persistence services
            builder.Services.AddPersistenceServices(builder.Configuration);
            //extensions services
            builder.Services.AddApiVersioningExtension();
            //identity services 
            builder.Services.AddIdentityServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UserErrorHandlingMiddleware();

            app.MapControllers();

            //scope
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await DefaultRoles.SeedAsync(userManager, roleManager);
                await DefaultAdminUser.SeedAsync(userManager, roleManager);

            }
            app.Run();
        }
    }
}
