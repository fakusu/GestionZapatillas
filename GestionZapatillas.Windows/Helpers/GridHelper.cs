using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.DTOs.Genre;
using GestionZapatillas.DTOs.Size;
using GestionZapatillas.DTOs.Sport;
using GestionZapatillas.DTOs.SportShoe;

namespace GestionZapatillas.Windows.Helpers
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView grid) => grid.Rows.Clear();

        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case BrandListDto brand:
                    r.Cells[0].Value = brand.BrandId;
                    r.Cells[1].Value = brand.BrandName;
                    r.Cells[2].Value = brand.Country;
                    r.Cells[3].Value = brand.Active;
                    break;
                case SportListDto sport:
                    r.Cells[0].Value = sport.SportId;
                    r.Cells[1].Value = sport.SportName;
                    r.Cells[2].Value = sport.Active;
                    break;
                case GenreListDto genre:
                    r.Cells[0].Value = genre.GenreId;
                    r.Cells[1].Value = genre.GenreName;
                    break;
                case SizeListDto size:
                    r.Cells[0].Value = size.SizeId;
                    r.Cells[1].Value = size.SizeNumber;
                    r.Cells[2].Value = size.Active;
                    break;
                case SportShoeListDto shoe:
                    r.Cells[0].Value = shoe.ShoeId;
                    r.Cells[1].Value = shoe.Model;
                    r.Cells[2].Value = shoe.BrandName;
                    r.Cells[3].Value = shoe.SportName;
                    r.Cells[4].Value = shoe.Price;
                    r.Cells[5].Value = shoe.Active;
                    break;
            }
            r.Tag = obj;
        }

        public static void AgregarFila(DataGridViewRow r, DataGridView grid) => grid.Rows.Add(r);
    }
}
