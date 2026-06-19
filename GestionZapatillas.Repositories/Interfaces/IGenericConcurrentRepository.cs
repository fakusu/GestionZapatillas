using GestionZapatillas.Entities;

namespace GestionZapatillas.Repositories.Interfaces
{
    public interface IGenericConcurrentRepository<T> : IGenericRepository<T>
        where T : class, IConcurrencyEntity
    {
        void Update(T entity, int id, byte[] rowVersion);
        void Delete(int id, byte[] rowVersion);
    }
}
