namespace GestionZapatillas.DTOs.SportShoe
{
    public class SportShoeUpdateDto
    {
        public int ShoeId { get; set; }
        public int BrandId { get; set; }
        public int SportId { get; set; }
        public int GenreId { get; set; }
        public string Model { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Active { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public List<ShoeSizeDto> Sizes { get; set; } = new();
    }
}
