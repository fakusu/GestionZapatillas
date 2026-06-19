using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace GestionZapatillas.Windows
{
    public partial class frmBrands : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<BrandListDto>? _lista;
        private bool _filtroActivo = false;

        public frmBrands(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmBrands_Load(object sender, EventArgs e) => RecargarGrilla();

        private void RecargarGrilla()
        {
            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IBrandService>();
            var resultado = service.GetAll();
            if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
            _lista = resultado.Value;
            MostrarEnGrilla(_lista);
        }

        private void MostrarEnGrilla(List<BrandListDto>? lista)
        {
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();
            using var frm = scope.ServiceProvider.GetRequiredService<frmBrandAe>();
            frm.Text = "Nueva Marca";
            frm.ShowDialog();
            if (frm.DataChanged) RecargarGrilla();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dto = (BrandListDto)dgvDatos.SelectedRows[0].Tag!;
            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IBrandService>();
            var resultado = service.GetForUpdate(dto.BrandId);
            if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
            using var frm = scope.ServiceProvider.GetRequiredService<frmBrandAe>();
            frm.Text = "Editar Marca";
            frm.SetBrand(resultado.Value!);
            frm.ShowDialog();
            if (frm.ConcurrencyConflict || frm.DataChanged) RecargarGrilla();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dto = (BrandListDto)dgvDatos.SelectedRows[0].Tag!;
            var dr = MessageBox.Show($"¿Desea eliminar la marca '{dto.BrandName}'?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;

            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IBrandService>();
            var resultado = service.Delete(dto.BrandId);
            if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
            MessageBox.Show("Marca eliminada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RecargarGrilla();
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e) => FiltrarPorActivo(true);
        private void noActivosToolStripMenuItem_Click(object sender, EventArgs e) => FiltrarPorActivo(false);

        private void FiltrarPorActivo(bool activo)
        {
            var filtrada = _lista?.Where(b => b.Active == activo).ToList();
            MostrarEnGrilla(filtrada);
            ManejarControles(true);
        }

        private void ManejarControles(bool filtroOn)
        {
            _filtroActivo = filtroOn;
            tsbFiltrar.BackColor = filtroOn ? Color.Orange : SystemColors.Control;
            tsbNuevo.Enabled = !filtroOn;
            tsbEditar.Enabled = !filtroOn;
            tsbEliminar.Enabled = !filtroOn;
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            ManejarControles(false);
        }

        private void tsbCerrar_Click(object sender, EventArgs e) => Close();
    }
}
