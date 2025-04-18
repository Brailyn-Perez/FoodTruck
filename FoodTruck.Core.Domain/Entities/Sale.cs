using FoodTruck.Core.Domain.Common;

namespace FoodTruck.Core.Domain.Entities
{
    public class Sale : AuditableEntity
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }

        //navigation properties
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
