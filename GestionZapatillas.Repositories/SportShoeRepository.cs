using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Repositories
{
    public class SportShoeRepository : ISportShoeRepository
    {
        private readonly ShoeDbContext _context;

        public SportShoeRepository(ShoeDbContext context)
        {
            _context = context;
        }

        public void Add(SportShoe sportShoe)
        {
            _context.SportShoes.Add(sportShoe);
        }

        public void Delete(int id)
        {
            var shoe = _context.SportShoes.Find(id);
            if (shoe == null) return;
            shoe.Active = false;
        }

        public bool Exist(string model, int brandId, int sizeId, int? shoeId = null)
        {
            if (shoeId == null)
                return _context.SportShoes.Any(ss =>
                    ss.Model == model && ss.BrandId == brandId &&
                    ss.ShoeSizes.Any(sz => sz.SizeId == sizeId));
            return _context.SportShoes.Any(ss =>
                ss.Model == model && ss.BrandId == brandId &&
                ss.ShoeSizes.Any(sz => sz.SizeId == sizeId) &&
                ss.ShoeId != shoeId);
        }

        public bool ExistByModelAndBrand(string model, int brandId, int? shoeId = null)
        {
            if (shoeId == null)
                return _context.SportShoes.Any(ss => ss.Model == model && ss.BrandId == brandId);
            return _context.SportShoes.Any(ss => ss.Model == model && ss.BrandId == brandId && ss.ShoeId != shoeId);
        }

        public List<SportShoe> GetAll()
        {
            return _context.SportShoes
                .Include(ss => ss.Brand)
                .Include(ss => ss.Sport)
                .Include(ss => ss.Genre)
                .Include(ss => ss.ShoeSizes)
                    .ThenInclude(sz => sz.Size)
                .AsNoTracking()
                .ToList();
        }

        public SportShoe? GetById(int id)
        {
            return _context.SportShoes
                .Include(ss => ss.Brand)
                .Include(ss => ss.Sport)
                .Include(ss => ss.Genre)
                .Include(ss => ss.ShoeSizes)
                    .ThenInclude(sz => sz.Size)
                .FirstOrDefault(ss => ss.ShoeId == id);
        }

        public List<SportShoe> GetByBrand(int brandId)
        {
            return _context.SportShoes
                .Where(ss => ss.Active && ss.BrandId == brandId)
                .Include(ss => ss.Brand)
                .Include(ss => ss.Sport)
                .Include(ss => ss.Genre)
                .Include(ss => ss.ShoeSizes)
                    .ThenInclude(sz => sz.Size)
                .AsNoTracking()
                .ToList();
        }

        public List<SportShoe> GetBySize(int sizeId)
        {
            return _context.SportShoes
                .Where(ss => ss.Active && ss.ShoeSizes.Any(sz => sz.SizeId == sizeId))
                .Include(ss => ss.Brand)
                .Include(ss => ss.Sport)
                .Include(ss => ss.Genre)
                .Include(ss => ss.ShoeSizes)
                    .ThenInclude(sz => sz.Size)
                .AsNoTracking()
                .ToList();
        }

        public List<SportShoe> GetBySport(int sportId)
        {
            return _context.SportShoes
                .Where(ss => ss.Active && ss.SportId == sportId)
                .Include(ss => ss.Brand)
                .Include(ss => ss.Sport)
                .Include(ss => ss.Genre)
                .Include(ss => ss.ShoeSizes)
                    .ThenInclude(sz => sz.Size)
                .AsNoTracking()
                .ToList();
        }

        public List<SportShoe> GetSortedByBrand()
        {
            return _context.SportShoes
                .Where(ss => ss.Active)
                .Include(ss => ss.Brand)
                .Include(ss => ss.Sport)
                .Include(ss => ss.Genre)
                .Include(ss => ss.ShoeSizes)
                    .ThenInclude(sz => sz.Size)
                .OrderBy(ss => ss.Brand.BrandName)
                .AsNoTracking()
                .ToList();
        }

        public List<SportShoe> GetSortedByModel()
        {
            return _context.SportShoes
                .Where(ss => ss.Active)
                .Include(ss => ss.Brand)
                .Include(ss => ss.Sport)
                .Include(ss => ss.Genre)
                .Include(ss => ss.ShoeSizes)
                    .ThenInclude(sz => sz.Size)
                .OrderBy(ss => ss.Model)
                .AsNoTracking()
                .ToList();
        }

        public List<SportShoe> GetSortedByPrice()
        {
            return _context.SportShoes
                .Where(ss => ss.Active)
                .Include(ss => ss.Brand)
                .Include(ss => ss.Sport)
                .Include(ss => ss.Genre)
                .Include(ss => ss.ShoeSizes)
                    .ThenInclude(sz => sz.Size)
                .OrderBy(ss => ss.Price)
                .AsNoTracking()
                .ToList();
        }

        public void Update(SportShoe sportShoe)
        {
            _context.SportShoes.Update(sportShoe);
        }

        public void UpdateConcurrent(SportShoe sportShoe, byte[] rowVersion)
        {
            var existing = _context.SportShoes
                .Include(ss => ss.ShoeSizes)
                .FirstOrDefault(ss => ss.ShoeId == sportShoe.ShoeId);
            if (existing == null) return;

            var entry = _context.Entry(existing);
            entry.OriginalValues["RowVersion"] = rowVersion;

            existing.Model = sportShoe.Model;
            existing.Description = sportShoe.Description;
            existing.Price = sportShoe.Price;
            existing.ReleaseDate = sportShoe.ReleaseDate;
            existing.BrandId = sportShoe.BrandId;
            existing.SportId = sportShoe.SportId;
            existing.GenreId = sportShoe.GenreId;
            existing.Active = sportShoe.Active;

            // Replace sizes
            existing.ShoeSizes.Clear();
            foreach (var sz in sportShoe.ShoeSizes)
            {
                existing.ShoeSizes.Add(new ShoeSize
                {
                    SizeId = sz.SizeId,
                    QuantityInStock = sz.QuantityInStock
                });
            }
        }
    }
}
