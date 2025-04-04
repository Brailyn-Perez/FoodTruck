namespace FoodTruck.Core.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public User User { get; set; }
    }
}
