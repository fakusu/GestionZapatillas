namespace GestionZapatillas.Windows
{
    partial class frmGenres
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            tsbActualizar = new ToolStripButton();
            sep1 = new ToolStripSeparator();
            tsbCerrar = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            panelBottom = new Panel();
            lblCantidadLbl = new Label();
            lblCantidad = new Label();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbActualizar, sep1, tsbCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(686, 27);
            toolStrip1.TabIndex = 1;
            // 
            // tsbActualizar
            // 
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(79, 24);
            tsbActualizar.Text = "Actualizar";
            tsbActualizar.Click += tsbActualizar_Click;
            // 
            // sep1
            // 
            sep1.Name = "sep1";
            sep1.Size = new Size(6, 27);
            // 
            // tsbCerrar
            // 
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(53, 24);
            tsbCerrar.Text = "Cerrar";
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 27);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelBottom);
            splitContainer1.Size = new Size(686, 573);
            splitContainer1.SplitterDistance = 497;
            splitContainer1.TabIndex = 0;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeColumns = false;
            dgvDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.ColumnHeadersVisible = false;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Margin = new Padding(3, 4, 3, 4);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(686, 497);
            dgvDatos.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblCantidadLbl);
            panelBottom.Controls.Add(lblCantidad);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(0, 0);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(686, 72);
            panelBottom.TabIndex = 0;
            // 
            // lblCantidadLbl
            // 
            lblCantidadLbl.AutoSize = true;
            lblCantidadLbl.Location = new Point(23, 20);
            lblCantidadLbl.Name = "lblCantidadLbl";
            lblCantidadLbl.Size = new Size(154, 20);
            lblCantidadLbl.TabIndex = 0;
            lblCantidadLbl.Text = "Cantidad de registros:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidad.Location = new Point(183, 20);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(18, 20);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "0";
            // 
            // colId
            // 
            colId.DataPropertyName = "GenreId";
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "GenreName";
            colNombre.HeaderText = "Género";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // frmGenres
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 600);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmGenres";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Géneros";
            Load += frmGenres_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStrip toolStrip1;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator sep1;
        private ToolStripButton tsbCerrar;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private Panel panelBottom;
        private Label lblCantidadLbl;
        private Label lblCantidad;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
    }
}
