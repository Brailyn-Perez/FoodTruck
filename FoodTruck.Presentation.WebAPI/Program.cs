using FoodTruck.IOC.Application;
using FoodTruck.IOC.Persistences;
using FoodTruck.Presentation.WebAPI.Extensions;

namespace FoodTruck.Presentation.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
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

            app.Run();
        }
    }
}
