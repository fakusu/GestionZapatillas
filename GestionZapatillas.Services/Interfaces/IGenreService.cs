using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.Genre;

namespace GestionZapatillas.Services.Interfaces
{
    public interface IGenreService
    {
        Result<List<GenreListDto>> GetAll();
    }
}
