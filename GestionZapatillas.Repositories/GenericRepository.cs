using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionZapatillas.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase
    {
        protected readonly ShoeDbContext _context;

        public GenericRepository(ShoeDbContext context)
        {
            _context = context;
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public virtual T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return;
            entity.Active = false;
        }
    }
}
