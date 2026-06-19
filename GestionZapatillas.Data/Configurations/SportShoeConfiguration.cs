using GestionZapatillas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionZapatillas.Data.Configurations
{
    public class SportShoeConfiguration : IEntityTypeConfiguration<SportShoe>
    {
        public void Configure(EntityTypeBuilder<SportShoe> builder)
        {
            builder.ToTable("Shoes");
            builder.HasKey(ss => ss.ShoeId);
            builder.Property(ss => ss.Model).IsRequired().HasMaxLength(150);
            builder.Property(ss => ss.Description).IsRequired();
            builder.Property(ss => ss.Price).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(ss => ss.ReleaseDate).HasColumnType("datetime2");
            builder.Property(ss => ss.Active).HasDefaultValue(true);
            builder.Property(ss => ss.RowVersion).IsRowVersion();

            builder.HasOne(ss => ss.Brand)
                .WithMany(b => b.SportShoes)
                .HasForeignKey(ss => ss.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ss => ss.Sport)
                .WithMany(s => s.SportShoes)
                .HasForeignKey(ss => ss.SportId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ss => ss.Genre)
                .WithMany(g => g.SportShoes)
                .HasForeignKey(ss => ss.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
