namespace GestionZapatillas.Entities
{
    public class ShoeSize
    {
        public int ShoeSizeId { get; set; }
        public int ShoeId { get; set; }
        public int SizeId { get; set; }
        public int QuantityInStock { get; set; }

        public SportShoe SportShoe { get; set; } = null!;
        public Size Size { get; set; } = null!;
    }
}
