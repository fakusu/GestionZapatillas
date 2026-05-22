namespace GestionZapatillas.DTOs.Brand
{
    public class BrandUpdateDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
