using GestionZapatillas.Entities;

namespace GestionZapatillas.Repositories.Interfaces
{
    public interface ISportRepository : IGenericConcurrentRepository<Sport>
    {
        bool Exist(string sportName, int? sportId = null);
    }
}
