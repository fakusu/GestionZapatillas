using GestionZapatillas.DTOs.Sport;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace GestionZapatillas.Windows
{
    public partial class frmSports : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private List<SportListDto>? _lista;
        private bool _filtroActivo = false;

        private BindingSource _bindingSource= new BindingSource();

        public frmSports(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmSports_Load(object sender, EventArgs e) => RecargarGrilla();

        private void RecargarGrilla()
        {
            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISportService>();
            var resultado = service.GetAll();
            if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
            _lista = resultado.Value;
            MostrarEnGrilla(_lista);
        }

        private void MostrarEnGrilla(List<SportListDto>? lista)
        {
            //GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is null || lista.Count == 0) { lblCantidad.Text = "0"; return; }
            var bindingList = new BindingList<SportListDto>(lista);
            _bindingSource.DataSource = bindingList;
            dgvDatos.DataSource = _bindingSource;
            //foreach (var item in lista)
            //{
            //    var r = GridHelper.ConstruirFila(dgvDatos);
            //    GridHelper.SetearFila(r, item);
            //    GridHelper.AgregarFila(r, dgvDatos);
            //}
            lblCantidad.Text = lista.Count.ToString();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();
            using var frm = scope.ServiceProvider.GetRequiredService<frmSportAe>();
            frm.Text = "Nuevo Deporte";
            frm.ShowDialog();
            if (frm.DataChanged) RecargarGrilla();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current==null)
            {
                MessageBox.Show("Debe seleccionar una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dto = (SportListDto)_bindingSource.Current;
            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISportService>();
            var resultado = service.GetForUpdate(dto.SportId);
            if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
            using var frm = scope.ServiceProvider.GetRequiredService<frmSportAe>();
            frm.Text = "Editar Deporte";
            frm.SetSport(resultado.Value!);
            frm.ShowDialog();
            if (frm.ConcurrencyConflict || frm.DataChanged) RecargarGrilla();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dto = (SportListDto)_bindingSource.Current;
            var dr = MessageBox.Show($"¿Desea eliminar el deporte '{dto.SportName}'?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;

            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ISportService>();
            var resultado = service.Delete(dto.SportId);
            if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
            MessageBox.Show("Deporte eliminado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RecargarGrilla();
        }

        private void activosToolStripMenuItem_Click(object sender, EventArgs e) => FiltrarPorActivo(true);
        private void noActivosToolStripMenuItem_Click(object sender, EventArgs e) => FiltrarPorActivo(false);

        private void FiltrarPorActivo(bool activo)
        {
            var filtrada = _lista?.Where(s => s.Active == activo).ToList();
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
