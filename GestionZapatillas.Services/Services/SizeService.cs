using FluentValidation;
using GestionZapatillas.Data;
using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.Size;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Mappers;

namespace GestionZapatillas.Services.Services
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _repository;
        private readonly IValidator<Entities.Size> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public SizeService(ISizeRepository repository, IValidator<Entities.Size> validator, IUnitOfWork unitOfWork)
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
                return Result.Fail<SizeDetailsDto>("Size not found");

            return Result.Ok(SizeMapper.ToDetailsDto(size));
        }

        public Result<SizeUpdateDto> GetForUpdate(int id)
        {
            var size = _repository.GetById(id);
            if (size == null)
                return Result.Fail<SizeUpdateDto>("Size not found");

            return Result.Ok(SizeMapper.ToUpdateDto(size));
        }

        public Result Update(SizeUpdateDto dto)
        {
            var size = _repository.GetById(dto.SizeId);
            if (size == null)
                return Result.Fail("Size not found");

            size.SizeNumber = dto.SizeNumber;

            var validation = _validator.Validate(size);
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
    }
}
