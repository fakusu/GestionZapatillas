namespace GestionZapatillas.Entities
{
    public class Sport : IEntityBase, IConcurrencyEntity
    {
        public int SportId { get; set; }
        public string SportName { get; set; } = null!;
        public bool Active { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        public ICollection<SportShoe> SportShoes { get; set; } = new List<SportShoe>();
    }
}
