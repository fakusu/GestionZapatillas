using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ShoeDbContext _context;

        public BrandRepository(ShoeDbContext context)
        {
            _context = context;
        }

        public void Add(Brand brand)
        {
            _context.Brands.Add(brand);
        }

        public void Delete(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null) return;
            brand.Active = false;
        }

        public bool Exist(string brandName, int? brandId = null)
        {
            if (brandId == null)
                return _context.Brands.Any(b => b.BrandName == brandName);
            return _context.Brands.Any(b => b.BrandName == brandName && b.BrandId != brandId);
        }

        public List<Brand> GetAll()
        {
            return _context.Brands.Where(b => b.Active).AsNoTracking().ToList();
        }

        public Brand? GetById(int id)
        {
            return _context.Brands.Find(id);
        }

        public void Update(Brand brand)
        {
            _context.Brands.Update(brand);
        }
    }
}
