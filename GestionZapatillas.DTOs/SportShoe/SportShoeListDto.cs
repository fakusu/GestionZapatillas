namespace GestionZapatillas.DTOs.SportShoe
{
    public class SportShoeListDto
    {
        public int ShoeId { get; set; }
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
        public string BrandName { get; set; } = null!;
        public string SportName { get; set; } = null!;
        public bool Active { get; set; }
    }
}
