﻿namespace FoodTruck.Core.Domain.Entities
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }



        public IQueryable<Product> Product { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
