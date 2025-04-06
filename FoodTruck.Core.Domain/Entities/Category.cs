using FoodTruck.Core.Domain.Common;

namespace FoodTruck.Core.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }


        public IEnumerable<Product>? Products { get; set; }
    }
}
