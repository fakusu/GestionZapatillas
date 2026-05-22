using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.Entities;

namespace GestionZapatillas.Services.Mappers
{
    public static class BrandMapper
    {
        public static BrandListDto ToListDto(Brand brand)
        {
            return new BrandListDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                Country = brand.Country
            };
        }

        public static BrandDetailsDto ToDetailsDto(Brand brand)
        {
            return new BrandDetailsDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                Country = brand.Country
            };
        }

        public static BrandUpdateDto ToUpdateDto(Brand brand)
        {
            return new BrandUpdateDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                Country = brand.Country
            };
        }

        public static Brand ToEntity(BrandCreateDto dto)
        {
            return new Brand
            {
                BrandName = dto.BrandName,
                Country = dto.Country,
                Active = true
            };
        }
    }
}
