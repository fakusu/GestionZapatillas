using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Windows.Helpers;

namespace GestionZapatillas.Windows
{
    public partial class frmBrandAe : Form
    {
        private readonly IBrandService _service;
        private BrandUpdateDto? _updateDto;
        private bool _esEdicion = false;

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        public frmBrandAe(IBrandService service)
        {
            InitializeComponent();
            _service = service;
        }

        public void SetBrand(BrandUpdateDto dto)
        {
            _updateDto = dto;
        }

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
                txtNombre.Text = _updateDto.BrandName;
                txtPais.Text = _updateDto.Country;
                chkActivo.Checked = true; // Active no está en UpdateDto, siempre activo en edición
                chkActivo.Enabled = false; // baja lógica se hace desde el listado
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
                    var createDto = new BrandCreateDto
                    {
                        BrandName = txtNombre.Text.Trim(),
                        Country = txtPais.Text.Trim()
                    };
                    var resultado = _service.Add(createDto);
                    if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
                    DataChanged = true;
                    var resp = MessageBox.Show("Marca agregada.\n¿Desea agregar otra?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (resp == DialogResult.No) { DialogResult = DialogResult.OK; }
                    else InicializarControles();
                }
                else
                {
                    _updateDto!.BrandName = txtNombre.Text.Trim();
                    _updateDto.Country = txtPais.Text.Trim();
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
                    MessageBox.Show("Marca actualizada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void InicializarControles()
        {
            txtNombre.Clear();
            txtPais.Clear();
            txtNombre.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es requerido.");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                errorProvider1.SetError(txtPais, "El país es requerido.");
                valido = false;
            }
            return valido;
        }
    }
}
