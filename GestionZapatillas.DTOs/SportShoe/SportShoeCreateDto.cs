namespace GestionZapatillas.DTOs.SportShoe
{
    public class SportShoeCreateDto
    {
        public int BrandId { get; set; }
        public int SportId { get; set; }
        public int GenreId { get; set; }
        public string Model { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ShoeSizeDto> Sizes { get; set; } = new();
    }

    public class ShoeSizeDto
    {
        public int SizeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
