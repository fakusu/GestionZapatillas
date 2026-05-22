using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.DTOs.Common;

namespace GestionZapatillas.Services.Interfaces
{
    public interface IBrandService
    {
        Result<List<BrandListDto>> GetAll();
        Result<BrandDetailsDto> GetById(int id);
        Result<BrandUpdateDto> GetForUpdate(int id);
        Result Add(BrandCreateDto dto);
        Result Update(BrandUpdateDto dto);
        Result Delete(int id);
    }
}
