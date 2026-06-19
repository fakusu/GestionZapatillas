using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.Size;

namespace GestionZapatillas.Services.Interfaces
{
    public interface ISizeService
    {
        Result<List<SizeListDto>> GetAll();
        Result<SizeDetailsDto> GetById(int id);
        Result<SizeUpdateDto> GetForUpdate(int id);
        Result Add(SizeCreateDto dto);
        Result Update(SizeUpdateDto dto);
        Result Delete(int id);
    }
}
