using GestionZapatillas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionZapatillas.Data.Configurations
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.ToTable("Sports");
            builder.HasKey(s => s.SportId);
            builder.Property(s => s.SportName).IsRequired().HasMaxLength(20);
            builder.Property(s => s.Active).HasDefaultValue(true);
            builder.HasIndex(s => s.SportName).IsUnique().HasDatabaseName("IX_Sports_SportName");

            builder.HasData(
                new Sport { SportId = 1, SportName = "Fútbol", Active = true },
                new Sport { SportId = 2, SportName = "Running", Active = true },
                new Sport { SportId = 3, SportName = "Outdoor", Active = true },
                new Sport { SportId = 4, SportName = "Urban", Active = true },
                new Sport { SportId = 5, SportName = "Training", Active = true },
                new Sport { SportId = 6, SportName = "Tenis", Active = true }
            );
        }
    }
}
