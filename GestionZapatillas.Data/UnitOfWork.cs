namespace GestionZapatillas.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoeDbContext _context;

        public UnitOfWork(ShoeDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
