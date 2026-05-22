using GestionZapatillas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionZapatillas.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasKey(g => g.GenreId);
            builder.Property(g => g.GenreName).IsRequired().HasMaxLength(10);
            builder.Property(g => g.Active).HasDefaultValue(true);
            builder.HasIndex(g => g.GenreName).IsUnique().HasDatabaseName("IX_Genres_GenreName");

            builder.HasData(
                new Genre { GenreId = 1, GenreName = "Masculino", Active = true },
                new Genre { GenreId = 2, GenreName = "Femenino", Active = true },
                new Genre { GenreId = 3, GenreName = "Unisex", Active = true }
            );
        }
    }
}
