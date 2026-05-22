using GestionZapatillas.DTOs.SportShoe;
using GestionZapatillas.Entities;

namespace GestionZapatillas.Services.Mappers
{
    public static class SportShoeMapper
    {
        public static SportShoeListDto ToListDto(SportShoe shoe)
        {
            return new SportShoeListDto
            {
                ShoeId = shoe.ShoeId,
                Model = shoe.Model,
                Price = shoe.Price,
                BrandName = shoe.Brand?.BrandName ?? "",
                SportName = shoe.Sport?.SportName ?? ""
            };
        }

        public static SportShoeDetailsDto ToDetailsDto(SportShoe shoe)
        {
            return new SportShoeDetailsDto
            {
                ShoeId = shoe.ShoeId,
                Model = shoe.Model,
                Description = shoe.Description,
                Price = shoe.Price,
                ReleaseDate = shoe.ReleaseDate,
                BrandName = shoe.Brand?.BrandName ?? "",
                SportName = shoe.Sport?.SportName ?? "",
                GenreName = shoe.Genre?.GenreName ?? "",
                Sizes = shoe.ShoeSizes.Select(sz => new ShoeSizeDetailDto
                {
                    ShoeSizeId = sz.ShoeSizeId,
                    SizeId = sz.SizeId,
                    SizeNumber = sz.Size.SizeNumber,
                    QuantityInStock = sz.QuantityInStock
                }).ToList()
            };
        }

        public static SportShoeUpdateDto ToUpdateDto(SportShoe shoe)
        {
            return new SportShoeUpdateDto
            {
                ShoeId = shoe.ShoeId,
                Model = shoe.Model,
                Description = shoe.Description,
                Price = shoe.Price,
                ReleaseDate = shoe.ReleaseDate,
                BrandId = shoe.BrandId,
                SportId = shoe.SportId,
                GenreId = shoe.GenreId,
                Active = shoe.Active,
                Sizes = shoe.ShoeSizes.Select(sz => new ShoeSizeDto
                {
                    SizeId = sz.SizeId,
                    QuantityInStock = sz.QuantityInStock
                }).ToList()
            };
        }
    }
}
