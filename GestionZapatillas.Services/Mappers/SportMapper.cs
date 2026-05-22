using GestionZapatillas.DTOs.Sport;
using GestionZapatillas.Entities;

namespace GestionZapatillas.Services.Mappers
{
    public static class SportMapper
    {
        public static SportListDto ToListDto(Sport sport)
        {
            return new SportListDto
            {
                SportId = sport.SportId,
                SportName = sport.SportName
            };
        }

        public static SportDetailsDto ToDetailsDto(Sport sport)
        {
            return new SportDetailsDto
            {
                SportId = sport.SportId,
                SportName = sport.SportName
            };
        }

        public static SportUpdateDto ToUpdateDto(Sport sport)
        {
            return new SportUpdateDto
            {
                SportId = sport.SportId,
                SportName = sport.SportName
            };
        }

        public static Sport ToEntity(SportCreateDto dto)
        {
            return new Sport
            {
                SportName = dto.SportName,
                Active = true
            };
        }
    }
}
