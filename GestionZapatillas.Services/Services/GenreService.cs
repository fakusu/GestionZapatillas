using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.Genre;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Mappers;

namespace GestionZapatillas.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public Result<List<GenreListDto>> GetAll()
        {
            var genres = _repository.GetAll().Select(GenreMapper.ToListDto).ToList();
            return Result.Ok(genres);
        }
    }
}
