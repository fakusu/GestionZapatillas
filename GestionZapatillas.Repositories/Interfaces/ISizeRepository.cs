using GestionZapatillas.Entities;

namespace GestionZapatillas.Repositories.Interfaces
{
    public interface ISizeRepository : IGenericConcurrentRepository<Size>
    {
        bool Exist(decimal sizeNumber, int? sizeId = null);
    }
}
