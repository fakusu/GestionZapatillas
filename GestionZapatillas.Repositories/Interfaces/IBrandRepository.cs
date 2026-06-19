using GestionZapatillas.Entities;

namespace GestionZapatillas.Repositories.Interfaces
{
    public interface IBrandRepository : IGenericConcurrentRepository<Brand>
    {
        bool Exist(string brandName, int? brandId = null);
    }
}
