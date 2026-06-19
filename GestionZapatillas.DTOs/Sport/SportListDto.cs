namespace GestionZapatillas.DTOs.Sport
{
    public class SportListDto
    {
        public int SportId { get; set; }
        public string SportName { get; set; } = null!;
        public bool Active { get; set; }
    }
}
