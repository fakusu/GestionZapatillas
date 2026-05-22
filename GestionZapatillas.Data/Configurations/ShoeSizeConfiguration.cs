using GestionZapatillas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionZapatillas.Data.Configurations
{
    public class ShoeSizeConfiguration : IEntityTypeConfiguration<ShoeSize>
    {
        public void Configure(EntityTypeBuilder<ShoeSize> builder)
        {
            builder.ToTable("ShoeSizes");
            builder.HasKey(ss => ss.ShoeSizeId);
            builder.Property(ss => ss.QuantityInStock).IsRequired().HasDefaultValue(0);

            builder.HasOne(ss => ss.SportShoe)
                .WithMany(s => s.ShoeSizes)
                .HasForeignKey(ss => ss.ShoeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ss => ss.Size)
                .WithMany(s => s.ShoeSizes)
                .HasForeignKey(ss => ss.SizeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ss => new { ss.ShoeId, ss.SizeId }).IsUnique().HasDatabaseName("IX_ShoeSizes_ShoeId_SizeId");
        }
    }
}
