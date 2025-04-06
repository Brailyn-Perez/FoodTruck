using FoodTruck.Core.Domain.Common;

namespace FoodTruck.Core.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Rol { get; set; }
    }
}
