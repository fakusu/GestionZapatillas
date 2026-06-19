using GestionZapatillas.DTOs.Size;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Windows.Helpers;

namespace GestionZapatillas.Windows
{
    public partial class frmSizeAe : Form
    {
        private readonly ISizeService _service;
        private SizeUpdateDto? _updateDto;
        private bool _esEdicion = false;

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        public frmSizeAe(ISizeService service)
        {
            InitializeComponent();
            _service = service;
        }

        public void SetSize(SizeUpdateDto dto) => _updateDto = dto;

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
                numNumero.Value = (decimal)_updateDto.SizeNumber;
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
                _esEdicion = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_esEdicion)
                {
                    var createDto = new SizeCreateDto { SizeNumber = numNumero.Value };
                    var resultado = _service.Add(createDto);
                    if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
                    DataChanged = true;
                    var resp = MessageBox.Show("Talle agregado.\n¿Desea agregar otro?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (resp == DialogResult.No) DialogResult = DialogResult.OK;
                    else { numNumero.Value = numNumero.Minimum; numNumero.Focus(); }
                }
                else
                {
                    _updateDto!.SizeNumber = numNumero.Value;
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
                    MessageBox.Show("Talle actualizado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
