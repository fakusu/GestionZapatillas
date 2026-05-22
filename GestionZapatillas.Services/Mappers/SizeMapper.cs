using GestionZapatillas.DTOs.Size;
using GestionZapatillas.Entities;

namespace GestionZapatillas.Services.Mappers
{
    public static class SizeMapper
    {
        public static SizeListDto ToListDto(Size size)
        {
            return new SizeListDto
            {
                SizeId = size.SizeId,
                SizeNumber = size.SizeNumber
            };
        }

        public static SizeDetailsDto ToDetailsDto(Size size)
        {
            return new SizeDetailsDto
            {
                SizeId = size.SizeId,
                SizeNumber = size.SizeNumber
            };
        }

        public static SizeUpdateDto ToUpdateDto(Size size)
        {
            return new SizeUpdateDto
            {
                SizeId = size.SizeId,
                SizeNumber = size.SizeNumber
            };
        }
    }
}
