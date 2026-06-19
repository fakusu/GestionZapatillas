using GestionZapatillas.Data;
using GestionZapatillas.Entities;
using GestionZapatillas.Repositories.Interfaces;

namespace GestionZapatillas.Repositories
{
    public class GenericConcurrentRepository<T> : GenericRepository<T>, IGenericConcurrentRepository<T>
        where T : class, IEntityBase, IConcurrencyEntity
    {
        public GenericConcurrentRepository(ShoeDbContext context) : base(context) { }

        public override void Update(T entity)
        {
            throw new NotImplementedException("Debe utilizar la versión con rowVersion: Update(entity, id, rowVersion)");
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException("Debe utilizar la versión con rowVersion: Delete(id, rowVersion)");
        }

        public void Update(T entity, int id, byte[] rowVersion)
        {
            var entityInDb = _context.Set<T>().Find(id);
            if (entityInDb is null)
                throw new KeyNotFoundException($"No se encontró el registro con ID: {id}");

            var entry = _context.Entry(entityInDb);
            entry.OriginalValues["RowVersion"] = rowVersion;
            entry.CurrentValues.SetValues(entity);
        }

        public void Delete(int id, byte[] rowVersion)
        {
            var entityInDb = _context.Set<T>().Find(id);
            if (entityInDb is null)
                throw new KeyNotFoundException($"No se encontró el registro con ID: {id}");

            var entry = _context.Entry(entityInDb);
            entry.OriginalValues["RowVersion"] = rowVersion;
            entityInDb.Active = false;
        }
    }
}
