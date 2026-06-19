using GestionZapatillas.DTOs.Brand;
using GestionZapatillas.DTOs.Genre;
using GestionZapatillas.DTOs.Size;
using GestionZapatillas.DTOs.Sport;
using GestionZapatillas.DTOs.SportShoe;
using GestionZapatillas.Services.Interfaces;
using GestionZapatillas.Windows.Helpers;

namespace GestionZapatillas.Windows
{
    public partial class frmSportShoeAe : Form
    {
        private readonly ISportShoeService _sportShoeService;
        private readonly IBrandService _brandService;
        private readonly ISportService _sportService;
        private readonly IGenreService _genreService;
        private readonly ISizeService _sizeService;

        private SportShoeUpdateDto? _updateDto;
        private bool _esEdicion = false;

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        public frmSportShoeAe(
            ISportShoeService sportShoeService,
            IBrandService brandService,
            ISportService sportService,
            IGenreService genreService,
            ISizeService sizeService)
        {
            InitializeComponent();
            _sportShoeService = sportShoeService;
            _brandService = brandService;
            _sportService = sportService;
            _genreService = genreService;
            _sizeService = sizeService;
        }

        public void SetShoe(SportShoeUpdateDto dto)
        {
            _updateDto = dto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarCombos();

            if (_updateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
                dtpFecha.Value = DateTime.Today;
            }
            else
            {
                _esEdicion = true;
                txtModelo.Text = _updateDto.Model;
                txtDescripcion.Text = _updateDto.Description;
                nudPrecio.Value = _updateDto.Price;
                dtpFecha.Value = _updateDto.ReleaseDate;
                chkActivo.Checked = _updateDto.Active;
                chkActivo.Enabled = true;
                cmbMarca.SelectedValue = _updateDto.BrandId;
                cmbDeporte.SelectedValue = _updateDto.SportId;
                cmbGenero.SelectedValue = _updateDto.GenreId;
                CargarTallesExistentes(_updateDto.Sizes);
            }
        }

        private void CargarCombos()
        {
            // Marcas activas
            var resBrands = _brandService.GetAll();
            if (!resBrands.IsFailure && resBrands.Value != null)
            {
                var brands = resBrands.Value.Where(b => b.Active).ToList();
                cmbMarca.DataSource = brands;
                cmbMarca.DisplayMember = nameof(BrandListDto.BrandName);
                cmbMarca.ValueMember = nameof(BrandListDto.BrandId);
            }

            // Deportes activos
            var resSports = _sportService.GetAll();
            if (!resSports.IsFailure && resSports.Value != null)
            {
                var sports = resSports.Value.Where(s => s.Active).ToList();
                cmbDeporte.DataSource = sports;
                cmbDeporte.DisplayMember = nameof(SportListDto.SportName);
                cmbDeporte.ValueMember = nameof(SportListDto.SportId);
            }

            // Géneros activos
            var resGenres = _genreService.GetAll();
            if (!resGenres.IsFailure && resGenres.Value != null)
            {
                cmbGenero.DataSource = resGenres.Value;
                cmbGenero.DisplayMember = nameof(GenreListDto.GenreName);
                cmbGenero.ValueMember = nameof(GenreListDto.GenreId);
            }

            // Talles activos para el combo de selección
            var resSizes = _sizeService.GetAll();
            if (!resSizes.IsFailure && resSizes.Value != null)
            {
                var sizes = resSizes.Value.Where(s => s.Active).ToList();
                cmbTalle.DataSource = sizes;
                cmbTalle.DisplayMember = nameof(SizeListDto.SizeNumber);
                cmbTalle.ValueMember = nameof(SizeListDto.SizeId);
            }
        }

        private void CargarTallesExistentes(List<ShoeSizeDto> sizes)
        {
            dgvTalles.Rows.Clear();
            var resSizes = _sizeService.GetAll();
            if (resSizes.IsFailure || resSizes.Value == null) return;

            foreach (var s in sizes)
            {
                var sizeInfo = resSizes.Value.FirstOrDefault(x => x.SizeId == s.SizeId);
                if (sizeInfo == null) continue;
                int idx = dgvTalles.Rows.Add();
                dgvTalles.Rows[idx].Cells[colTalleId.Index].Value = s.SizeId;
                dgvTalles.Rows[idx].Cells[colTalleNum.Index].Value = sizeInfo.SizeNumber;
                dgvTalles.Rows[idx].Cells[colCantidad.Index].Value = s.QuantityInStock;
            }
        }

        private void btnAgregarTalle_Click(object sender, EventArgs e)
        {
            if (cmbTalle.SelectedItem is not SizeListDto selectedSize) return;

            // Si el talle ya está en la grilla, sumar la cantidad
            foreach (DataGridViewRow row in dgvTalles.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToInt32(row.Cells[colTalleId.Index].Value) == selectedSize.SizeId)
                {
                    int existente = Convert.ToInt32(row.Cells[colCantidad.Index].Value);
                    row.Cells[colCantidad.Index].Value = existente + (int)nudCantidad.Value;
                    return;
                }
            }

            // Si no existe, agregar nueva fila
            int idx = dgvTalles.Rows.Add();
            dgvTalles.Rows[idx].Cells[colTalleId.Index].Value = selectedSize.SizeId;
            dgvTalles.Rows[idx].Cells[colTalleNum.Index].Value = selectedSize.SizeNumber;
            dgvTalles.Rows[idx].Cells[colCantidad.Index].Value = (int)nudCantidad.Value;
        }

        private void btnQuitarTalle_Click(object sender, EventArgs e)
        {
            if (dgvTalles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un talle para quitar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvTalles.Rows.Remove(dgvTalles.SelectedRows[0]);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            var sizes = ObtenerTalles();

            try
            {
                if (!_esEdicion)
                {
                    var createDto = new SportShoeCreateDto
                    {
                        BrandId = (int)cmbMarca.SelectedValue!,
                        SportId = (int)cmbDeporte.SelectedValue!,
                        GenreId = (int)cmbGenero.SelectedValue!,
                        Model = txtModelo.Text.Trim(),
                        Description = txtDescripcion.Text.Trim(),
                        Price = nudPrecio.Value,
                        ReleaseDate = dtpFecha.Value,
                        Sizes = sizes
                    };
                    var resultado = _sportShoeService.Add(createDto);
                    if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
                    DataChanged = true;
                    var resp = MessageBox.Show("Zapatilla agregada.\n¿Desea agregar otra?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (resp == DialogResult.No) { DialogResult = DialogResult.OK; }
                    else InicializarControles();
                }
                else
                {
                    _updateDto!.BrandId = (int)cmbMarca.SelectedValue!;
                    _updateDto.SportId = (int)cmbDeporte.SelectedValue!;
                    _updateDto.GenreId = (int)cmbGenero.SelectedValue!;
                    _updateDto.Model = txtModelo.Text.Trim();
                    _updateDto.Description = txtDescripcion.Text.Trim();
                    _updateDto.Price = nudPrecio.Value;
                    _updateDto.ReleaseDate = dtpFecha.Value;
                    _updateDto.Active = chkActivo.Checked;
                    _updateDto.Sizes = sizes;

                    var resultado = _sportShoeService.Update(_updateDto);
                    if (resultado.IsConcurrencyConflict)
                    {
                        ConcurrencyConflict = true;
                        MessageBox.Show("La zapatilla fue modificada por otro usuario. Se recargarán los datos.", "Conflicto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.Cancel;
                        return;
                    }
                    if (resultado.IsFailure) { ErrorHelper.MostrarErrores(resultado.Errors); return; }
                    DataChanged = true;
                    MessageBox.Show("Zapatilla actualizada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private List<ShoeSizeDto> ObtenerTalles()
        {
            var sizes = new List<ShoeSizeDto>();
            foreach (DataGridViewRow row in dgvTalles.Rows)
            {
                if (row.IsNewRow) continue;
                sizes.Add(new ShoeSizeDto
                {
                    SizeId = Convert.ToInt32(row.Cells[colTalleId.Index].Value),
                    QuantityInStock = Convert.ToInt32(row.Cells[colCantidad.Index].Value)
                });
            }
            return sizes;
        }

        private void InicializarControles()
        {
            txtModelo.Clear();
            txtDescripcion.Clear();
            nudPrecio.Value = 0;
            dtpFecha.Value = DateTime.Today;
            dgvTalles.Rows.Clear();
            if (cmbMarca.Items.Count > 0) cmbMarca.SelectedIndex = 0;
            if (cmbDeporte.Items.Count > 0) cmbDeporte.SelectedIndex = 0;
            if (cmbGenero.Items.Count > 0) cmbGenero.SelectedIndex = 0;
            txtModelo.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (cmbMarca.SelectedValue == null)
            {
                errorProvider1.SetError(cmbMarca, "Seleccione una marca.");
                valido = false;
            }
            if (cmbDeporte.SelectedValue == null)
            {
                errorProvider1.SetError(cmbDeporte, "Seleccione un deporte.");
                valido = false;
            }
            if (cmbGenero.SelectedValue == null)
            {
                errorProvider1.SetError(cmbGenero, "Seleccione un género.");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                errorProvider1.SetError(txtModelo, "El modelo es requerido.");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider1.SetError(txtDescripcion, "La descripción es requerida.");
                valido = false;
            }
            if (nudPrecio.Value <= 0)
            {
                errorProvider1.SetError(nudPrecio, "El precio debe ser mayor a cero.");
                valido = false;
            }
            if (dgvTalles.Rows.Count == 0 || (dgvTalles.Rows.Count == 1 && dgvTalles.Rows[0].IsNewRow))
            {
                MessageBox.Show("Debe agregar al menos un talle.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
            }

            return valido;
        }
    }
}
