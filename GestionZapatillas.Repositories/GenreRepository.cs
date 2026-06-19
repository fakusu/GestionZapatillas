using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ShoeDbContext context) : base(context) { }

        public override List<Genre> GetAll()
        {
            return _context.Genres.Where(g => g.Active).AsNoTracking().ToList();
        }
    }
}
