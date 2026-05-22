using GestionZapatillas.Entities;

namespace GestionZapatillas.Repositories.Interfaces
{
    public interface ISportRepository
    {
        List<Sport> GetAll();
        Sport? GetById(int id);
        void Add(Sport sport);
        void Update(Sport sport);
        void Delete(int id);
        bool Exist(string sportName, int? sportId = null);
    }
}
