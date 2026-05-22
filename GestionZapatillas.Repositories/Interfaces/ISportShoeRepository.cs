using GestionZapatillas.Entities;

namespace GestionZapatillas.Repositories.Interfaces
{
    public interface ISportShoeRepository
    {
        List<SportShoe> GetAll();
        SportShoe? GetById(int id);
        void Add(SportShoe sportShoe);
        void Update(SportShoe sportShoe);
        void Delete(int id);
        List<SportShoe> GetByBrand(int brandId);
        List<SportShoe> GetBySport(int sportId);
        List<SportShoe> GetBySize(int sizeId);
        List<SportShoe> GetSortedByModel();
        List<SportShoe> GetSortedByPrice();
        List<SportShoe> GetSortedByBrand();
        bool Exist(string model, int brandId, int sizeId, int? shoeId = null);
    }
}
