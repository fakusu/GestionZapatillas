namespace GestionZapatillas.Entities
{
    public class Brand : IEntityBase, IConcurrencyEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Country { get; set; } = null!;
        public bool Active { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        public ICollection<SportShoe> SportShoes { get; set; } = new List<SportShoe>();
    }
}
