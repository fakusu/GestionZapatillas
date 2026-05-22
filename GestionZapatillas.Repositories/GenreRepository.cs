using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ShoeDbContext _context;

        public GenreRepository(ShoeDbContext context)
        {
            _context = context;
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.Where(g => g.Active).AsNoTracking().ToList();
        }
    }
}
