using FluentValidation;
using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.Size;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Services.Services
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _repository;
        private readonly IValidator<Size> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public SizeService(ISizeRepository repository, IValidator<Size> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public Result<List<SizeListDto>> GetAll()
        {
            var sizes = _repository.GetAll().Select(SizeMapper.ToListDto).ToList();
            return Result.Ok(sizes);
        }

        public Result<SizeDetailsDto> GetById(int id)
        {
            var size = _repository.GetById(id);
            if (size == null)
                return Result.Fail<SizeDetailsDto>("Talle no encontrado.");

            return Result.Ok(SizeMapper.ToDetailsDto(size));
        }

        public Result<SizeUpdateDto> GetForUpdate(int id)
        {
            var size = _repository.GetById(id);
            if (size == null)
                return Result.Fail<SizeUpdateDto>("Talle no encontrado.");

            return Result.Ok(SizeMapper.ToUpdateDto(size));
        }

        public Result Add(SizeCreateDto dto)
        {
            var size = SizeMapper.ToEntity(dto);

            var validation = _validator.Validate(size);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _repository.Add(size);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error al guardar: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Update(SizeUpdateDto dto)
        {
            var size = new Size
            {
                SizeId = dto.SizeId,
                SizeNumber = dto.SizeNumber,
                Active = true,
                RowVersion = dto.RowVersion
            };

            var validation = _validator.Validate(size);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _repository.Update(size, dto.SizeId, dto.RowVersion);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (KeyNotFoundException)
            {
                return Result.Fail("Talle no encontrado.");
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
            var size = _repository.GetById(id);
            if (size == null)
                return Result.Fail("Talle no encontrado.");

            try
            {
                _repository.Delete(id, size.RowVersion);
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
