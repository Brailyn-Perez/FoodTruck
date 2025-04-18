using FoodTruck.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTruck.Infraestructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Birthdate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Age)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Rol)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            // Relationships
            builder.HasMany(x => x.Sales);
        }
    }
}
