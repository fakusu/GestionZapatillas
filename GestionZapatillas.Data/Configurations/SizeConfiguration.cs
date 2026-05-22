using GestionZapatillas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionZapatillas.Data.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Sizes");
            builder.HasKey(s => s.SizeId);
            builder.Property(s => s.SizeNumber).IsRequired().HasColumnType("decimal(3,1)");
            builder.Property(s => s.Active).HasDefaultValue(true);
            builder.HasIndex(s => s.SizeNumber).IsUnique().HasDatabaseName("IX_Sizes_SizeNumber");

            var sizes = new List<Size>();
            decimal number = 28.0m;
            for (int id = 1; id <= 46; id++)
            {
                sizes.Add(new Size { SizeId = id, SizeNumber = number, Active = true });
                number += 0.5m;
            }
            builder.HasData(sizes);
        }
    }
}
