using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Repositories
{
    public class SportRepository : ISportRepository
    {
        private readonly ShoeDbContext _context;

        public SportRepository(ShoeDbContext context)
        {
            _context = context;
        }

        public void Add(Sport sport)
        {
            _context.Sports.Add(sport);
        }

        public void Delete(int id)
        {
            var sport = _context.Sports.Find(id);
            if (sport == null) return;
            sport.Active = false;
        }

        public bool Exist(string sportName, int? sportId = null)
        {
            if (sportId == null)
                return _context.Sports.Any(s => s.SportName == sportName);
            return _context.Sports.Any(s => s.SportName == sportName && s.SportId != sportId);
        }

        public List<Sport> GetAll()
        {
            return _context.Sports.Where(s => s.Active).AsNoTracking().ToList();
        }

        public Sport? GetById(int id)
        {
            return _context.Sports.Find(id);
        }

        public void Update(Sport sport)
        {
            _context.Sports.Update(sport);
        }
    }
}
