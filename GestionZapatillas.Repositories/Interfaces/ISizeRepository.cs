using GestionZapatillas.Entities;

namespace GestionZapatillas.Repositories.Interfaces
{
    public interface ISizeRepository
    {
        List<Size> GetAll();
        Size? GetById(int id);
        void Update(Size size);
        bool Exist(decimal sizeNumber, int? sizeId = null);
    }
}
