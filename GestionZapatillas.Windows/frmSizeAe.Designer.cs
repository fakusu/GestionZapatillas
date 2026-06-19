namespace GestionZapatillas.Windows
{
    partial class frmSizeAe
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            numNumero = new NumericUpDown();
            label2 = new Label();
            chkActivo = new CheckBox();
            btnOK = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numNumero).BeginInit();
            SuspendLayout();
            // label1
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Text = "Número:";
            // numNumero
            numNumero.DecimalPlaces = 1;
            numNumero.Increment = new decimal(new int[] { 5, 0, 0, 65536 }); // 0.5
            numNumero.Location = new Point(110, 27);
            numNumero.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numNumero.Minimum = new decimal(new int[] { 1, 0, 0, 65536 }); // 0.1
            numNumero.Size = new Size(120, 23);
            numNumero.TabIndex = 0;
            numNumero.Value = new decimal(new int[] { 280, 0, 0, 65536 }); // 28.0
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
            btnCancelar.Location = new Point(230, 120);
            btnCancelar.Size = new Size(90, 35);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // frmSizeAe
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 180);
            Controls.Add(chkActivo);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(numNumero);
            Controls.Add(label1);
            MaximumSize = new Size(396, 219);
            MinimumSize = new Size(396, 219);
            Name = "frmSizeAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Talle";
            ((System.ComponentModel.ISupportInitialize)numNumero).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private NumericUpDown numNumero;
        private Label label2;
        private CheckBox chkActivo;
        private Button btnOK;
        private Button btnCancelar;
    }
}
