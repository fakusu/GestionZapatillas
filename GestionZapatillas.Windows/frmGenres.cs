using GestionZapatillas.DTOs.Genre;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace GestionZapatillas.Windows
{
    public partial class frmGenres : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public frmGenres(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmGenres_Load(object sender, EventArgs e) => RecargarGrilla();

        private void RecargarGrilla()
        {
            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IGenreService>();
            var resultado = service.GetAll();
            if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
            var lista = resultado.Value;
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is null || lista.Count == 0) { lblCantidad.Text = "0"; return; }
            foreach (var item in lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvDatos);
            }
            lblCantidad.Text = lista.Count.ToString();
        }

        private void tsbActualizar_Click(object sender, EventArgs e) => RecargarGrilla();
        private void tsbCerrar_Click(object sender, EventArgs e) => Close();
    }
}
