namespace GestionZapatillas.Entities
{
    public interface IConcurrencyEntity
    {
        byte[] RowVersion { get; set; }
    }
}
