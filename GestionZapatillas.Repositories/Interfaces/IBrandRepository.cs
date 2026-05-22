using GestionZapatillas.Entities;

namespace GestionZapatillas.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        Brand? GetById(int id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(int id);
        bool Exist(string brandName, int? brandId = null);
    }
}
