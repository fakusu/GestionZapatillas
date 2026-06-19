using FluentValidation;
using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.DTOs.Common;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IValidator<Brand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository repository, IValidator<Brand> validator, IUnitOfWork unitOfWork)
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
                return Result.Fail<BrandDetailsDto>("Marca no encontrada.");

            return Result.Ok(BrandMapper.ToDetailsDto(brand));
        }

        public Result<BrandUpdateDto> GetForUpdate(int id)
        {
            var brand = _repository.GetById(id);
            if (brand == null)
                return Result.Fail<BrandUpdateDto>("Marca no encontrada.");

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
                return Result.Fail($"Error al guardar: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Update(BrandUpdateDto dto)
        {
            var brand = new Brand
            {
                BrandId = dto.BrandId,
                BrandName = dto.BrandName,
                Country = dto.Country,
                Active = true,
                RowVersion = dto.RowVersion
            };

            var validation = _validator.Validate(brand);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _repository.Update(brand, dto.BrandId, dto.RowVersion);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (KeyNotFoundException)
            {
                return Result.Fail("Marca no encontrada.");
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
            var brand = _repository.GetById(id);
            if (brand == null)
                return Result.Fail("Marca no encontrada.");

            try
            {
                _repository.Delete(id, brand.RowVersion);
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
