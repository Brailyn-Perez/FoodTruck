using FoodTruck.Core.Domain.Common;

namespace FoodTruck.Core.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public string? imageUrl { get; set; }
        public int Stock { get; set; }

        public int? categoryId { get; set; }
        public Category? category { get; set; }
    }
}
