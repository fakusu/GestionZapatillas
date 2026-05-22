namespace GestionZapatillas.DTOs.SportShoe
{
    public class SportShoeDetailsDto
    {
        public int ShoeId { get; set; }
        public string Model { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string BrandName { get; set; } = null!;
        public string SportName { get; set; } = null!;
        public string GenreName { get; set; } = null!;
        public List<ShoeSizeDetailDto> Sizes { get; set; } = new();
    }

    public class ShoeSizeDetailDto
    {
        public int ShoeSizeId { get; set; }
        public int SizeId { get; set; }
        public decimal SizeNumber { get; set; }
        public int QuantityInStock { get; set; }
    }
}
