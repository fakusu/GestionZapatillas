using FluentValidation;
using GestionZapatillas.Data;
using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.DTOs.Common;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Mappers;

namespace GestionZapatillas.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IValidator<Entities.Brand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository repository, IValidator<Entities.Brand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public Result<List<BrandListDto>> GetAll()
        {
            var brands = _repository.GetAll().Select(BrandMapper.ToListDto).ToList();
            return Result.Ok(brands);
        }

        public Result<BrandDetailsDto> GetById(int id)
        {
            var brand = _repository.GetById(id);
            if (brand == null)
                return Result.Fail<BrandDetailsDto>("Brand not found");

            return Result.Ok(BrandMapper.ToDetailsDto(brand));
        }

        public Result<BrandUpdateDto> GetForUpdate(int id)
        {
            var brand = _repository.GetById(id);
            if (brand == null)
                return Result.Fail<BrandUpdateDto>("Brand not found");

            return Result.Ok(BrandMapper.ToUpdateDto(brand));
        }

        public Result Add(BrandCreateDto dto)
        {
            var brand = BrandMapper.ToEntity(dto);

            var validation = _validator.Validate(brand);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _repository.Add(brand);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Update(BrandUpdateDto dto)
        {
            var brand = _repository.GetById(dto.BrandId);
            if (brand == null)
                return Result.Fail("Brand not found");

            brand.BrandName = dto.BrandName;
            brand.Country = dto.Country;

            var validation = _validator.Validate(brand);
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
            var brand = _repository.GetById(id);
            if (brand == null)
                return Result.Fail("Brand not found");

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
