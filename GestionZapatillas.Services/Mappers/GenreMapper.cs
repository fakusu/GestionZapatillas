using GestionZapatillas.DTOs.Genre;
using GestionZapatillas.Entities;

namespace GestionZapatillas.Services.Mappers
{
    public static class GenreMapper
    {
        public static GenreListDto ToListDto(Genre genre)
        {
            return new GenreListDto
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName
            };
        }
    }
}
