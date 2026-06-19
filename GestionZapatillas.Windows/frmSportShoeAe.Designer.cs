namespace GestionZapatillas.Windows
{
    partial class frmSportShoeAe
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpDatos = new GroupBox();
            lblMarca = new Label();
            cmbMarca = new ComboBox();
            lblDeporte = new Label();
            cmbDeporte = new ComboBox();
            lblGenero = new Label();
            cmbGenero = new ComboBox();
            lblModelo = new Label();
            txtModelo = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrecio = new Label();
            nudPrecio = new NumericUpDown();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblActivo = new Label();
            chkActivo = new CheckBox();
            grpTalles = new GroupBox();
            lblTalle = new Label();
            cmbTalle = new ComboBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnAgregarTalle = new Button();
            dgvTalles = new DataGridView();
            colTalleId = new DataGridViewTextBoxColumn();
            colTalleNum = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            btnQuitarTalle = new Button();
            panelBotones = new Panel();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            grpTalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTalles).BeginInit();
            panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // grpDatos
            grpDatos.Controls.Add(lblMarca);
            grpDatos.Controls.Add(cmbMarca);
            grpDatos.Controls.Add(lblDeporte);
            grpDatos.Controls.Add(cmbDeporte);
            grpDatos.Controls.Add(lblGenero);
            grpDatos.Controls.Add(cmbGenero);
            grpDatos.Controls.Add(lblModelo);
            grpDatos.Controls.Add(txtModelo);
            grpDatos.Controls.Add(lblDescripcion);
            grpDatos.Controls.Add(txtDescripcion);
            grpDatos.Controls.Add(lblPrecio);
            grpDatos.Controls.Add(nudPrecio);
            grpDatos.Controls.Add(lblFecha);
            grpDatos.Controls.Add(dtpFecha);
            grpDatos.Controls.Add(lblActivo);
            grpDatos.Controls.Add(chkActivo);
            grpDatos.Location = new Point(12, 10);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(640, 295);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos de la Zapatilla";
            // lblMarca
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(15, 30);
            lblMarca.Text = "Marca:";
            // cmbMarca
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.Location = new Point(130, 27);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(220, 23);
            cmbMarca.TabIndex = 0;
            // lblDeporte
            lblDeporte.AutoSize = true;
            lblDeporte.Location = new Point(15, 65);
            lblDeporte.Text = "Deporte:";
            // cmbDeporte
            cmbDeporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDeporte.Location = new Point(130, 62);
            cmbDeporte.Name = "cmbDeporte";
            cmbDeporte.Size = new Size(220, 23);
            cmbDeporte.TabIndex = 1;
            // lblGenero
            lblGenero.AutoSize = true;
            lblGenero.Location = new Point(15, 100);
            lblGenero.Text = "Género:";
            // cmbGenero
            cmbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenero.Location = new Point(130, 97);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(220, 23);
            cmbGenero.TabIndex = 2;
            // lblModelo
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(15, 135);
            lblModelo.Text = "Modelo:";
            // txtModelo
            txtModelo.Location = new Point(130, 132);
            txtModelo.MaxLength = 100;
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(490, 23);
            txtModelo.TabIndex = 3;
            // lblDescripcion
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(15, 168);
            lblDescripcion.Text = "Descripción:";
            // txtDescripcion
            txtDescripcion.Location = new Point(130, 165);
            txtDescripcion.MaxLength = 500;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(490, 55);
            txtDescripcion.TabIndex = 4;
            // lblPrecio
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(15, 235);
            lblPrecio.Text = "Precio:";
            // nudPrecio
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Location = new Point(130, 232);
            nudPrecio.Maximum = 999999;
            nudPrecio.Minimum = 0;
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(120, 23);
            nudPrecio.TabIndex = 5;
            // lblFecha
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(270, 235);
            lblFecha.Text = "Fecha lanzamiento:";
            // dtpFecha
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(400, 232);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(170, 23);
            dtpFecha.TabIndex = 6;
            // lblActivo
            lblActivo.AutoSize = true;
            lblActivo.Location = new Point(15, 265);
            lblActivo.Text = "Activo:";
            // chkActivo
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(130, 263);
            chkActivo.Name = "chkActivo";
            chkActivo.TabIndex = 7;
            // grpTalles
            grpTalles.Controls.Add(lblTalle);
            grpTalles.Controls.Add(cmbTalle);
            grpTalles.Controls.Add(lblCantidad);
            grpTalles.Controls.Add(nudCantidad);
            grpTalles.Controls.Add(btnAgregarTalle);
            grpTalles.Controls.Add(dgvTalles);
            grpTalles.Controls.Add(btnQuitarTalle);
            grpTalles.Location = new Point(12, 315);
            grpTalles.Name = "grpTalles";
            grpTalles.Size = new Size(640, 210);
            grpTalles.TabIndex = 1;
            grpTalles.TabStop = false;
            grpTalles.Text = "Talles";
            // lblTalle
            lblTalle.AutoSize = true;
            lblTalle.Location = new Point(15, 30);
            lblTalle.Text = "Talle:";
            // cmbTalle
            cmbTalle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTalle.Location = new Point(65, 27);
            cmbTalle.Name = "cmbTalle";
            cmbTalle.Size = new Size(110, 23);
            cmbTalle.TabIndex = 0;
            // lblCantidad
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(190, 30);
            lblCantidad.Text = "Cantidad:";
            // nudCantidad
            nudCantidad.Location = new Point(255, 27);
            nudCantidad.Maximum = 9999;
            nudCantidad.Minimum = 1;
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(80, 23);
            nudCantidad.TabIndex = 1;
            nudCantidad.Value = 1;
            // btnAgregarTalle
            btnAgregarTalle.Location = new Point(350, 25);
            btnAgregarTalle.Name = "btnAgregarTalle";
            btnAgregarTalle.Size = new Size(85, 27);
            btnAgregarTalle.TabIndex = 2;
            btnAgregarTalle.Text = "Agregar";
            btnAgregarTalle.Click += btnAgregarTalle_Click;
            // dgvTalles
            dgvTalles.AllowUserToAddRows = false;
            dgvTalles.AllowUserToDeleteRows = false;
            dgvTalles.AllowUserToResizeRows = false;
            dgvTalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTalles.Columns.AddRange(new DataGridViewColumn[] { colTalleId, colTalleNum, colCantidad });
            dgvTalles.Location = new Point(15, 62);
            dgvTalles.MultiSelect = false;
            dgvTalles.Name = "dgvTalles";
            dgvTalles.RowHeadersVisible = false;
            dgvTalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTalles.Size = new Size(610, 110);
            dgvTalles.TabIndex = 3;
            // colTalleId
            colTalleId.HeaderText = "Id";
            colTalleId.Name = "colTalleId";
            colTalleId.ReadOnly = true;
            colTalleId.Visible = false;
            colTalleId.Width = 50;
            // colTalleNum
            colTalleNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTalleNum.HeaderText = "Talle";
            colTalleNum.Name = "colTalleNum";
            colTalleNum.ReadOnly = true;
            // colCantidad
            colCantidad.HeaderText = "Cantidad en Stock";
            colCantidad.Name = "colCantidad";
            colCantidad.Width = 140;
            // btnQuitarTalle
            btnQuitarTalle.Location = new Point(520, 178);
            btnQuitarTalle.Name = "btnQuitarTalle";
            btnQuitarTalle.Size = new Size(105, 27);
            btnQuitarTalle.TabIndex = 4;
            btnQuitarTalle.Text = "Quitar talle";
            btnQuitarTalle.Click += btnQuitarTalle_Click;
            // panelBotones
            panelBotones.Controls.Add(btnOK);
            panelBotones.Controls.Add(btnCancelar);
            panelBotones.Dock = DockStyle.Bottom;
            panelBotones.Height = 55;
            panelBotones.Name = "panelBotones";
            panelBotones.TabIndex = 2;
            // btnOK
            btnOK.Location = new Point(140, 10);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 35);
            btnOK.TabIndex = 0;
            btnOK.Text = "Aceptar";
            btnOK.Click += btnOK_Click;
            // btnCancelar
            btnCancelar.Location = new Point(420, 10);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // errorProvider1
            errorProvider1.ContainerControl = this;
            // frmSportShoeAe
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 595);
            Controls.Add(grpDatos);
            Controls.Add(grpTalles);
            Controls.Add(panelBotones);
            MaximumSize = new Size(680, 634);
            MinimumSize = new Size(680, 634);
            Name = "frmSportShoeAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zapatilla";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            grpTalles.ResumeLayout(false);
            grpTalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTalles).EndInit();
            panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox grpDatos;
        private Label lblMarca;
        private ComboBox cmbMarca;
        private Label lblDeporte;
        private ComboBox cmbDeporte;
        private Label lblGenero;
        private ComboBox cmbGenero;
        private Label lblModelo;
        private TextBox txtModelo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblPrecio;
        private NumericUpDown nudPrecio;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblActivo;
        private CheckBox chkActivo;
        private GroupBox grpTalles;
        private Label lblTalle;
        private ComboBox cmbTalle;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnAgregarTalle;
        private DataGridView dgvTalles;
        private DataGridViewTextBoxColumn colTalleId;
        private DataGridViewTextBoxColumn colTalleNum;
        private DataGridViewTextBoxColumn colCantidad;
        private Button btnQuitarTalle;
        private Panel panelBotones;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
