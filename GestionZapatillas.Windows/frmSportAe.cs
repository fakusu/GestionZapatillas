using GestionZapatillas.DTOs.Sport;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Windows.Helpers;

namespace GestionZapatillas.Windows
{
    public partial class frmSportAe : Form
    {
        private readonly ISportService _service;
        private SportUpdateDto? _updateDto;
        private bool _esEdicion = false;

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        public frmSportAe(ISportService service)
        {
            InitializeComponent();
            _service = service;
        }

        public void SetSport(SportUpdateDto dto) => _updateDto = dto;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_updateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtNombre.Text = _updateDto.SportName;
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
                _esEdicion = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;
            try
            {
                if (!_esEdicion)
                {
                    var createDto = new SportCreateDto { SportName = txtNombre.Text.Trim() };
                    var resultado = _service.Add(createDto);
                    if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
                    DataChanged = true;
                    var resp = MessageBox.Show("Deporte agregado.\n¿Desea agregar otro?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (resp == DialogResult.No) DialogResult = DialogResult.OK;
                    else { txtNombre.Clear(); txtNombre.Focus(); }
                }
                else
                {
                    _updateDto!.SportName = txtNombre.Text.Trim();
                    var resultado = _service.Update(_updateDto);
                    if (resultado.IsConcurrencyConflict)
                    {
                        ErrorHelper.MostrarErrores(resultado.Errors);
                        ConcurrencyConflict = true;
                        DialogResult = DialogResult.Cancel;
                        Close();
                        return;
                    }
                    if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
                    DataChanged = true;
                    MessageBox.Show("Deporte actualizado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es requerido.");
                return false;
            }
            return true;
        }
    }
}
