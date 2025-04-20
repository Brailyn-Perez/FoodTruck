using Microsoft.AspNetCore.Identity;

namespace FoodTruck.Infraestructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
