using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;

namespace GestionZapatillas.Repositories
{
    public class BrandRepository : GenericConcurrentRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ShoeDbContext context) : base(context) { }

        public bool Exist(string brandName, int? brandId = null)
        {
            if (brandId == null)
                return _context.Brands.Any(b => b.BrandName == brandName);
            return _context.Brands.Any(b => b.BrandName == brandName && b.BrandId != brandId);
        }
    }
}
