using GestionZapatillas.DTOs.Common;
using GestionZapatillas.DTOs.Sport;

namespace GestionZapatillas.Services.Interfaces
{
    public interface ISportService
    {
        Result<List<SportListDto>> GetAll();
        Result<SportDetailsDto> GetById(int id);
        Result<SportUpdateDto> GetForUpdate(int id);
        Result Add(SportCreateDto dto);
        Result Update(SportUpdateDto dto);
        Result Delete(int id);
    }
}
