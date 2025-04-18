using FoodTruck.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTruck.Infraestructure.Persistence.Configuration
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("SaleDetails");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Subtotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasMany(x => x.Products);

            builder.HasOne(x => x.Sale)
                .WithMany()
                .HasForeignKey(x => x.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
