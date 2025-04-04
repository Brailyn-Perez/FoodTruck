using FoodTruck.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infraestructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<SaleDetail> saleDetails { get; set; }
    }
}
