namespace GestionZapatillas.DTOs.Brand
{
    public class BrandListDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Country { get; set; } = null!;
        public bool Active { get; set; }
    }
}
