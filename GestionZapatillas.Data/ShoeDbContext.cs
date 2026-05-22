using GestionZapatillas.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Data
{
    public class ShoeDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SportShoe> SportShoes { get; set; }
        public DbSet<ShoeSize> ShoeSizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\MSQLSERVER; Initial Catalog=ShoesDb2026; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoeDbContext).Assembly);
        }
    }
}
