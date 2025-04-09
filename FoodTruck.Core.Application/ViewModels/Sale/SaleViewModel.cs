namespace FoodTruck.Core.Application.ViewModels.Sale
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
