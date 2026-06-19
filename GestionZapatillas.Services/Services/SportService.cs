using FluentValidation;
using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.Sport;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Services.Services
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _repository;
        private readonly IValidator<Sport> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public SportService(ISportRepository repository, IValidator<Sport> validator, IUnitOfWork unitOfWork)
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
                return Result.Fail<SportDetailsDto>("Deporte no encontrado.");

            return Result.Ok(SportMapper.ToDetailsDto(sport));
        }

        public Result<SportUpdateDto> GetForUpdate(int id)
        {
            var sport = _repository.GetById(id);
            if (sport == null)
                return Result.Fail<SportUpdateDto>("Deporte no encontrado.");

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
                return Result.Fail($"Error al guardar: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Update(SportUpdateDto dto)
        {
            var sport = new Sport
            {
                SportId = dto.SportId,
                SportName = dto.SportName,
                Active = true,
                RowVersion = dto.RowVersion
            };

            var validation = _validator.Validate(sport);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _repository.Update(sport, dto.SportId, dto.RowVersion);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (KeyNotFoundException)
            {
                return Result.Fail("Deporte no encontrado.");
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.Concurrency("El registro fue modificado por otro usuario.\nLos cambios no pueden guardarse porque los datos actuales son diferentes a los que usted visualizó.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error al guardar: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Delete(int id)
        {
            var sport = _repository.GetById(id);
            if (sport == null)
                return Result.Fail("Deporte no encontrado.");

            try
            {
                _repository.Delete(id, sport.RowVersion);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.Concurrency("El registro fue modificado por otro usuario.\nNo se pudo eliminar.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error al eliminar: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}
