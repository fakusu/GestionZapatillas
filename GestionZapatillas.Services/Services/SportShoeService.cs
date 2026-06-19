using FluentValidation;
using GestionZapatillas.Data;
using GestionZapatillas.Repositories.Interfaces;
using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.SportShoe;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Services.Mappers;
using GestionZapatillas.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Services.Services
{
    public class SportShoeService : ISportShoeService
    {
        private readonly ISportShoeRepository _repository;
        private readonly IValidator<SportShoe> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public SportShoeService(ISportShoeRepository repository, IValidator<SportShoe> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public Result<List<SportShoeListDto>> GetAll()
        {
            var shoes = _repository.GetAll().Select(SportShoeMapper.ToListDto).ToList();
            return Result.Ok(shoes);
        }

        public Result<SportShoeDetailsDto> GetById(int id)
        {
            var shoe = _repository.GetById(id);
            if (shoe == null)
                return Result.Fail<SportShoeDetailsDto>("SportShoe not found");

            return Result.Ok(SportShoeMapper.ToDetailsDto(shoe));
        }

        public Result<SportShoeUpdateDto> GetForUpdate(int id)
        {
            var shoe = _repository.GetById(id);
            if (shoe == null)
                return Result.Fail<SportShoeUpdateDto>("SportShoe not found");

            return Result.Ok(SportShoeMapper.ToUpdateDto(shoe));
        }

        public Result Add(SportShoeCreateDto dto)
        {
            if (_repository.ExistByModelAndBrand(dto.Model, dto.BrandId))
                return Result.Fail("Ya existe una zapatilla con ese modelo y marca.");

            var shoe = new SportShoe
            {
                Model = dto.Model,
                Description = dto.Description,
                Price = dto.Price,
                ReleaseDate = dto.ReleaseDate,
                BrandId = dto.BrandId,
                SportId = dto.SportId,
                GenreId = dto.GenreId,
                Active = true,
                ShoeSizes = dto.Sizes.Select(s => new ShoeSize
                {
                    SizeId = s.SizeId,
                    QuantityInStock = s.QuantityInStock
                }).ToList()
            };

            var validation = _validator.Validate(shoe);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _repository.Add(shoe);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Update(SportShoeUpdateDto dto)
        {
            if (_repository.ExistByModelAndBrand(dto.Model, dto.BrandId, dto.ShoeId))
                return Result.Fail("Ya existe otra zapatilla con ese modelo y marca.");

            var updatedShoe = new SportShoe
            {
                ShoeId = dto.ShoeId,
                Model = dto.Model,
                Description = dto.Description,
                Price = dto.Price,
                ReleaseDate = dto.ReleaseDate,
                BrandId = dto.BrandId,
                SportId = dto.SportId,
                GenreId = dto.GenreId,
                Active = dto.Active,
                ShoeSizes = dto.Sizes.Select(s => new ShoeSize
                {
                    SizeId = s.SizeId,
                    QuantityInStock = s.QuantityInStock
                }).ToList()
            };

            var validation = _validator.Validate(updatedShoe);
            if (!validation.IsValid)
                return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                _repository.UpdateConcurrent(updatedShoe, dto.RowVersion);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.Concurrency("La zapatilla fue modificada por otro usuario. Reintente.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Delete(int id)
        {
            var shoe = _repository.GetById(id);
            if (shoe == null)
                return Result.Fail("SportShoe not found");

            try
            {
                _repository.Delete(id);
                _unitOfWork.Save();
                return Result.Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.Concurrency("La zapatilla fue modificada por otro usuario. Reintente.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result<List<SportShoeListDto>> GetByBrand(int brandId)
        {
            var shoes = _repository.GetByBrand(brandId).Select(SportShoeMapper.ToListDto).ToList();
            return Result.Ok(shoes);
        }

        public Result<List<SportShoeListDto>> GetBySport(int sportId)
        {
            var shoes = _repository.GetBySport(sportId).Select(SportShoeMapper.ToListDto).ToList();
            return Result.Ok(shoes);
        }

        public Result<List<SportShoeListDto>> GetBySize(int sizeId)
        {
            var shoes = _repository.GetBySize(sizeId).Select(SportShoeMapper.ToListDto).ToList();
            return Result.Ok(shoes);
        }

        public Result<List<SportShoeListDto>> GetSortedByModel()
        {
            var shoes = _repository.GetSortedByModel().Select(SportShoeMapper.ToListDto).ToList();
            return Result.Ok(shoes);
        }

        public Result<List<SportShoeListDto>> GetSortedByPrice()
        {
            var shoes = _repository.GetSortedByPrice().Select(SportShoeMapper.ToListDto).ToList();
            return Result.Ok(shoes);
        }

        public Result<List<SportShoeListDto>> GetSortedByBrand()
        {
            var shoes = _repository.GetSortedByBrand().Select(SportShoeMapper.ToListDto).ToList();
            return Result.Ok(shoes);
        }
    }
}
