namespace GestionZapatillas.Windows.Helpers
{
    public static class ErrorHelper
    {
        public static void MostrarErrores(List<string> errores)
        {
            string mensaje = string.Join("\n", errores);
            MessageBox.Show(mensaje, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
