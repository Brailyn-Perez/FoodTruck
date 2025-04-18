using FoodTruck.Core.Domain.Common;

namespace FoodTruck.Core.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public User()
        {
            Age = Birthdate.Year - DateTime.Now.Year;
        }

        //navigation properties
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();

    }
}
