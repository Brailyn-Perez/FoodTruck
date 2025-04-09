
namespace FoodTruck.Core.Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public string? imageUrl { get; set; }
        public int Stock { get; set; }

    }
}
