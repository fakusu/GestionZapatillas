using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;

namespace GestionZapatillas.Repositories
{
    public class SportRepository : GenericConcurrentRepository<Sport>, ISportRepository
    {
        public SportRepository(ShoeDbContext context) : base(context) { }

        public bool Exist(string sportName, int? sportId = null)
        {
            if (sportId == null)
                return _context.Sports.Any(s => s.SportName == sportName);
            return _context.Sports.Any(s => s.SportName == sportName && s.SportId != sportId);
        }
    }
}
