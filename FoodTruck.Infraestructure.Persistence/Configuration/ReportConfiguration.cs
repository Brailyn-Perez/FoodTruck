using FoodTruck.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTruck.Infraestructure.Persistence.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(r => r.StartDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(r => r.EndDate)
                .IsRequired()
                .HasColumnType("datetime");
            builder.Property(r => r.TotalSales)
                .IsRequired();

            builder.Property(r => r.TotalRevenue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
