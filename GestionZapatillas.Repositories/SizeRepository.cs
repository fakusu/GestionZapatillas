using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Repositories
{
    public class SizeRepository : GenericConcurrentRepository<Size>, ISizeRepository
    {
        public SizeRepository(ShoeDbContext context) : base(context) { }

        public override List<Size> GetAll()
        {
            return _context.Sizes.OrderBy(s => s.SizeNumber).AsNoTracking().ToList();
        }

        public bool Exist(decimal sizeNumber, int? sizeId = null)
        {
            if (sizeId == null)
                return _context.Sizes.Any(s => s.SizeNumber == sizeNumber);
            return _context.Sizes.Any(s => s.SizeNumber == sizeNumber && s.SizeId != sizeId);
        }
    }
}
