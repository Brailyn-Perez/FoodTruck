using FoodTruck.Core.Domain.Common;

namespace FoodTruck.Core.Domain.Entities
{
    public class SaleDetail : AuditableEntity
    {
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }


        //navigation properties
        public IEnumerable<Product> Products { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
