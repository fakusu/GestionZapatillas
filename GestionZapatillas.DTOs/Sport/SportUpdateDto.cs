namespace GestionZapatillas.DTOs.Sport
{
    public class SportUpdateDto
    {
        public int SportId { get; set; }
        public string SportName { get; set; } = null!;
        public byte[] RowVersion { get; set; } = null!;
    }
}
