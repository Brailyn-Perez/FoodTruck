namespace FoodTruck.Core.Domain.Entities
{
    public class Product
    {
        int id { get; set; }
        string name { get; set; }
        string description { get; set; }
        decimal price { get; set; }
        string imageUrl { get; set; }
        int categoryId { get; set; }
        int Stock { get; set; }
    }
}
