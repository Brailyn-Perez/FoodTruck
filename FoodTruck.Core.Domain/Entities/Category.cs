using FoodTruck.Core.Domain.Common;

namespace FoodTruck.Core.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        //navigation properties
        public IEnumerable<Product>? Products { get; set; }
    }
}
