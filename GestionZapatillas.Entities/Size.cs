namespace GestionZapatillas.Entities
{
    public class Size
    {
        public int SizeId { get; set; }
        public decimal SizeNumber { get; set; }
        public bool Active { get; set; }

        public ICollection<ShoeSize> ShoeSizes { get; set; } = new List<ShoeSize>();
    }
}
