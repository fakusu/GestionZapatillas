namespace GestionZapatillas.Entities
{
    public class Size : IEntityBase, IConcurrencyEntity
    {
        public int SizeId { get; set; }
        public decimal SizeNumber { get; set; }
        public bool Active { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        public ICollection<ShoeSize> ShoeSizes { get; set; } = new List<ShoeSize>();
    }
}
