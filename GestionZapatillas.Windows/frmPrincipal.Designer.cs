namespace GestionZapatillas.Windows
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            label1 = new Label();
            lblFecha = new Label();
            labelFechaLbl = new Label();
            panelMenu = new Panel();
            btnBrands = new Button();
            btnSports = new Button();
            btnGenres = new Button();
            btnSizes = new Button();
            btnZapatillas = new Button();
            btnSalir = new Button();
            panelContent = new Panel();
            lblBienvenida = new Label();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // panelTop
            panelTop.BackColor = Color.FromArgb(30, 30, 80);
            panelTop.Controls.Add(labelFechaLbl);
            panelTop.Controls.Add(lblFecha);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Size = new Size(900, 64);
            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 16);
            label1.Text = "SportShoes S.A.";
            // labelFechaLbl
            labelFechaLbl.AutoSize = true;
            labelFechaLbl.ForeColor = Color.LightGray;
            labelFechaLbl.Location = new Point(620, 24);
            labelFechaLbl.Text = "Fecha:";
            // lblFecha
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(665, 24);
            lblFecha.Text = "01/01/2026";
            // panelMenu
            panelMenu.BackColor = Color.FromArgb(45, 45, 100);
            panelMenu.Controls.Add(btnSalir);
            panelMenu.Controls.Add(btnZapatillas);
            panelMenu.Controls.Add(btnSizes);
            panelMenu.Controls.Add(btnGenres);
            panelMenu.Controls.Add(btnSports);
            panelMenu.Controls.Add(btnBrands);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 64);
            panelMenu.Size = new Size(200, 486);
            // btnBrands
            btnBrands.BackColor = Color.FromArgb(60, 60, 130);
            btnBrands.FlatStyle = FlatStyle.Flat;
            btnBrands.ForeColor = Color.White;
            btnBrands.Location = new Point(15, 20);
            btnBrands.Size = new Size(170, 36);
            btnBrands.Text = "Marcas";
            btnBrands.Click += btnBrands_Click;
            // btnSports
            btnSports.BackColor = Color.FromArgb(60, 60, 130);
            btnSports.FlatStyle = FlatStyle.Flat;
            btnSports.ForeColor = Color.White;
            btnSports.Location = new Point(15, 66);
            btnSports.Size = new Size(170, 36);
            btnSports.Text = "Deportes";
            btnSports.Click += btnSports_Click;
            // btnGenres
            btnGenres.BackColor = Color.FromArgb(60, 60, 130);
            btnGenres.FlatStyle = FlatStyle.Flat;
            btnGenres.ForeColor = Color.White;
            btnGenres.Location = new Point(15, 112);
            btnGenres.Size = new Size(170, 36);
            btnGenres.Text = "Géneros";
            btnGenres.Click += btnGenres_Click;
            // btnSizes
            btnSizes.BackColor = Color.FromArgb(60, 60, 130);
            btnSizes.FlatStyle = FlatStyle.Flat;
            btnSizes.ForeColor = Color.White;
            btnSizes.Location = new Point(15, 158);
            btnSizes.Size = new Size(170, 36);
            btnSizes.Text = "Talles";
            btnSizes.Click += btnSizes_Click;
            // btnZapatillas
            btnZapatillas.BackColor = Color.FromArgb(60, 60, 130);
            btnZapatillas.FlatStyle = FlatStyle.Flat;
            btnZapatillas.ForeColor = Color.White;
            btnZapatillas.Location = new Point(15, 204);
            btnZapatillas.Size = new Size(170, 36);
            btnZapatillas.Text = "Zapatillas";
            btnZapatillas.Click += btnZapatillas_Click;
            // btnSalir
            btnSalir.BackColor = Color.FromArgb(140, 40, 40);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(15, 420);
            btnSalir.Size = new Size(170, 36);
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // panelContent
            panelContent.Controls.Add(lblBienvenida);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 64);
            panelContent.Size = new Size(700, 486);
            // lblBienvenida
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 14F);
            lblBienvenida.ForeColor = Color.Gray;
            lblBienvenida.Location = new Point(180, 210);
            lblBienvenida.Text = "Seleccione una opción del menú";
            // frmPrincipal
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SportShoes S.A. - Gestión";
            Load += frmPrincipal_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label label1;
        private Label lblFecha;
        private Label labelFechaLbl;
        private Panel panelMenu;
        private Button btnBrands;
        private Button btnSports;
        private Button btnGenres;
        private Button btnSizes;
        private Button btnZapatillas;
        private Button btnSalir;
        private Panel panelContent;
        private Label lblBienvenida;
    }
}
