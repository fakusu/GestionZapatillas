namespace GestionZapatillas.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Country { get; set; } = null!;
        public bool Active { get; set; }

        public ICollection<SportShoe> SportShoes { get; set; } = new List<SportShoe>();
    }
}
