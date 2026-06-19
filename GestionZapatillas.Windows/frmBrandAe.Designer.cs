namespace GestionZapatillas.Windows
{
    partial class frmBrandAe
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
            label1 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtPais = new TextBox();
            label3 = new Label();
            chkActivo = new CheckBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // label1
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Text = "Nombre:";
            // txtNombre
            txtNombre.Location = new Point(110, 27);
            txtNombre.MaxLength = 50;
            txtNombre.Size = new Size(300, 23);
            txtNombre.TabIndex = 0;
            // label2
            label2.AutoSize = true;
            label2.Location = new Point(30, 68);
            label2.Text = "País:";
            // txtPais
            txtPais.Location = new Point(110, 65);
            txtPais.MaxLength = 50;
            txtPais.Size = new Size(300, 23);
            txtPais.TabIndex = 1;
            // label3
            label3.AutoSize = true;
            label3.Location = new Point(30, 106);
            label3.Text = "Activo:";
            // chkActivo
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(110, 104);
            chkActivo.TabIndex = 2;
            // btnOK
            btnOK.Location = new Point(50, 150);
            btnOK.Size = new Size(90, 35);
            btnOK.TabIndex = 3;
            btnOK.Text = "Aceptar";
            btnOK.Click += btnOK_Click;
            // btnCancelar
            btnCancelar.Location = new Point(310, 150);
            btnCancelar.Size = new Size(90, 35);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // errorProvider1
            errorProvider1.ContainerControl = this;
            // frmBrandAe
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 210);
            Controls.Add(chkActivo);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtPais);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            MaximumSize = new Size(476, 249);
            MinimumSize = new Size(476, 249);
            Name = "frmBrandAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marca";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtPais;
        private Label label3;
        private CheckBox chkActivo;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
