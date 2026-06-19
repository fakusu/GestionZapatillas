namespace GestionZapatillas.Windows
{
    partial class frmSportAe
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
            txtNombre.MaxLength = 20;
            txtNombre.Size = new Size(280, 23);
            txtNombre.TabIndex = 0;
            // label2
            label2.AutoSize = true;
            label2.Location = new Point(30, 68);
            label2.Text = "Activo:";
            // chkActivo
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(110, 66);
            chkActivo.TabIndex = 1;
            // btnOK
            btnOK.Location = new Point(50, 120);
            btnOK.Size = new Size(90, 35);
            btnOK.TabIndex = 2;
            btnOK.Text = "Aceptar";
            btnOK.Click += btnOK_Click;
            // btnCancelar
            btnCancelar.Location = new Point(270, 120);
            btnCancelar.Size = new Size(90, 35);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // errorProvider1
            errorProvider1.ContainerControl = this;
            // frmSportAe
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 180);
            Controls.Add(chkActivo);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            MaximumSize = new Size(436, 219);
            MinimumSize = new Size(436, 219);
            Name = "frmSportAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Deporte";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private CheckBox chkActivo;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
