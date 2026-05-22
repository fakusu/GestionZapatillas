using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.SportShoe;

namespace GestionZapatillas.Services.Interfaces
{
    public interface ISportShoeService
    {
        Result<List<SportShoeListDto>> GetAll();
        Result<SportShoeDetailsDto> GetById(int id);
        Result<SportShoeUpdateDto> GetForUpdate(int id);
        Result Add(SportShoeCreateDto dto);
        Result Update(SportShoeUpdateDto dto);
        Result Delete(int id);
        Result<List<SportShoeListDto>> GetByBrand(int brandId);
        Result<List<SportShoeListDto>> GetBySport(int sportId);
        Result<List<SportShoeListDto>> GetBySize(int sizeId);
        Result<List<SportShoeListDto>> GetSortedByModel();
        Result<List<SportShoeListDto>> GetSortedByPrice();
        Result<List<SportShoeListDto>> GetSortedByBrand();
    }
}
