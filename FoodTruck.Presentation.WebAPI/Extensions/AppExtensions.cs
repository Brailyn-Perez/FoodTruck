using FoodTruck.Presentation.WebAPI.Middlewares;

namespace FoodTruck.Presentation.WebAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UserErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
