﻿namespace FoodTruck.Core.Domain.Entities
{
    public class Report
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalSales { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
