using FluentValidation;
using GestionZapatillas.Data;
using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.Sport;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Mappers;

namespace GestionZapatillas.Services.Services
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _repository;
        private readonly IValidator<Entities.Sport> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public SportService(ISportRepository repository, IValidator<Entities.Sport> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public Result<List<SportListDto>> GetAll()
        {
            var sports = _repository.GetAll().Select(SportMapper.ToListDto).ToList();
            return Result.Ok(sports);
        }

        public Result<SportDetailsDto> GetById(int id)
        {
            var sport = _repository.GetById(id);
            if (sport == null)
                return Result.Fail<SportDetailsDto>("Sport not found");

            return Result.Ok(SportMapper.ToDetailsDto(sport));
        }

        public Result<SportUpdateDto> GetForUpdate(int id)
        {
            var sport = _repository.GetById(id);
            if (sport == null)
                return Result.Fail<SportUpdateDto>("Sport not found");

            return Result.Ok(SportMapper.ToUpdateDto(sport));
        }

        public Result Add(SportCreateDto dto)
        {
            var sport = SportMapper.ToEntity(dto);

            var validation = _validator.Validate(sport);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _repository.Add(sport);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Update(SportUpdateDto dto)
        {
            var sport = _repository.GetById(dto.SportId);
            if (sport == null)
                return Result.Fail("Sport not found");

            sport.SportName = dto.SportName;

            var validation = _validator.Validate(sport);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Delete(int id)
        {
            var sport = _repository.GetById(id);
            if (sport == null)
                return Result.Fail("Sport not found");

            try
            {
                _repository.Delete(id);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}
