using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly ShoeDbContext _context;

        public SizeRepository(ShoeDbContext context)
        {
            _context = context;
        }

        public bool Exist(decimal sizeNumber, int? sizeId = null)
        {
            if (sizeId == null)
                return _context.Sizes.Any(s => s.SizeNumber == sizeNumber);
            return _context.Sizes.Any(s => s.SizeNumber == sizeNumber && s.SizeId != sizeId);
        }

        public List<Size> GetAll()
        {
            return _context.Sizes.Where(s => s.Active).AsNoTracking().ToList();
        }

        public Size? GetById(int id)
        {
            return _context.Sizes.Find(id);
        }

        public void Update(Size size)
        {
            _context.Sizes.Update(size);
        }
    }
}
