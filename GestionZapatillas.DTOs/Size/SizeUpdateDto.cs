namespace GestionZapatillas.DTOs.Size
{
    public class SizeUpdateDto
    {
        public int SizeId { get; set; }
        public decimal SizeNumber { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
