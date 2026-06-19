using GestionZapatillas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionZapatillas.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(b => b.BrandId);
            builder.Property(b => b.BrandName).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Country).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Active).HasDefaultValue(true);
            builder.Property(b => b.RowVersion).IsRowVersion();
            builder.HasIndex(b => b.BrandName).IsUnique().HasDatabaseName("IX_Brands_BrandName");

            builder.HasData(
                new Brand { BrandId = 1, BrandName = "Adidas", Country = "Alemania", Active = true },
                new Brand { BrandId = 2, BrandName = "Nike", Country = "Estados Unidos", Active = true },
                new Brand { BrandId = 3, BrandName = "Topper", Country = "Argentina", Active = true },
                new Brand { BrandId = 4, BrandName = "Reebok", Country = "Estados Unidos", Active = true }
            );
        }
    }
}
