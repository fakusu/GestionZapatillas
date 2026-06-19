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
            panelMenu = new Panel();
            btnSalir = new Button();
            btnZapatillas = new Button();
            btnSizes = new Button();
            btnGenres = new Button();
            btnSports = new Button();
            btnBrands = new Button();
            panelContent = new Panel();
            lblBienvenida = new Label();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(30, 30, 80);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1029, 85);
            panelTop.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 21);
            label1.Name = "label1";
            label1.Size = new Size(219, 37);
            label1.TabIndex = 2;
            label1.Text = "SportShoes S.A.";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(45, 45, 100);
            panelMenu.Controls.Add(btnSalir);
            panelMenu.Controls.Add(btnZapatillas);
            panelMenu.Controls.Add(btnSizes);
            panelMenu.Controls.Add(btnGenres);
            panelMenu.Controls.Add(btnSports);
            panelMenu.Controls.Add(btnBrands);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 85);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(229, 648);
            panelMenu.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(140, 40, 40);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(17, 560);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(194, 48);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnZapatillas
            // 
            btnZapatillas.BackColor = Color.FromArgb(60, 60, 130);
            btnZapatillas.FlatStyle = FlatStyle.Flat;
            btnZapatillas.ForeColor = Color.White;
            btnZapatillas.Location = new Point(17, 272);
            btnZapatillas.Margin = new Padding(3, 4, 3, 4);
            btnZapatillas.Name = "btnZapatillas";
            btnZapatillas.Size = new Size(194, 48);
            btnZapatillas.TabIndex = 1;
            btnZapatillas.Text = "Zapatillas";
            btnZapatillas.UseVisualStyleBackColor = false;
            btnZapatillas.Click += btnZapatillas_Click;
            // 
            // btnSizes
            // 
            btnSizes.BackColor = Color.FromArgb(60, 60, 130);
            btnSizes.FlatStyle = FlatStyle.Flat;
            btnSizes.ForeColor = Color.White;
            btnSizes.Location = new Point(17, 211);
            btnSizes.Margin = new Padding(3, 4, 3, 4);
            btnSizes.Name = "btnSizes";
            btnSizes.Size = new Size(194, 48);
            btnSizes.TabIndex = 2;
            btnSizes.Text = "Talles";
            btnSizes.UseVisualStyleBackColor = false;
            btnSizes.Click += btnSizes_Click;
            // 
            // btnGenres
            // 
            btnGenres.BackColor = Color.FromArgb(60, 60, 130);
            btnGenres.FlatStyle = FlatStyle.Flat;
            btnGenres.ForeColor = Color.White;
            btnGenres.Location = new Point(17, 149);
            btnGenres.Margin = new Padding(3, 4, 3, 4);
            btnGenres.Name = "btnGenres";
            btnGenres.Size = new Size(194, 48);
            btnGenres.TabIndex = 3;
            btnGenres.Text = "Géneros";
            btnGenres.UseVisualStyleBackColor = false;
            btnGenres.Click += btnGenres_Click;
            // 
            // btnSports
            // 
            btnSports.BackColor = Color.FromArgb(60, 60, 130);
            btnSports.FlatStyle = FlatStyle.Flat;
            btnSports.ForeColor = Color.White;
            btnSports.Location = new Point(17, 88);
            btnSports.Margin = new Padding(3, 4, 3, 4);
            btnSports.Name = "btnSports";
            btnSports.Size = new Size(194, 48);
            btnSports.TabIndex = 4;
            btnSports.Text = "Deportes";
            btnSports.UseVisualStyleBackColor = false;
            btnSports.Click += btnSports_Click;
            // 
            // btnBrands
            // 
            btnBrands.BackColor = Color.FromArgb(60, 60, 130);
            btnBrands.FlatStyle = FlatStyle.Flat;
            btnBrands.ForeColor = Color.White;
            btnBrands.Location = new Point(17, 27);
            btnBrands.Margin = new Padding(3, 4, 3, 4);
            btnBrands.Name = "btnBrands";
            btnBrands.Size = new Size(194, 48);
            btnBrands.TabIndex = 5;
            btnBrands.Text = "Marcas";
            btnBrands.UseVisualStyleBackColor = false;
            btnBrands.Click += btnBrands_Click;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(lblBienvenida);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(229, 85);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(800, 648);
            panelContent.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 14F);
            lblBienvenida.ForeColor = Color.Gray;
            lblBienvenida.Location = new Point(206, 280);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(364, 32);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Seleccione una opción del menú";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 733);
            ControlBox = false;
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            Margin = new Padding(3, 4, 3, 4);
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
