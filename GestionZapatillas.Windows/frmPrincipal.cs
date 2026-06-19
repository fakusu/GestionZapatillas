using Microsoft.Extensions.DependencyInjection;

namespace GestionZapatillas.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public frmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            using var frm = _serviceProvider.GetRequiredService<frmBrands>();
            frm.Text = "Marcas";
            frm.ShowDialog();
        }

        private void btnSports_Click(object sender, EventArgs e)
        {
            using var frm = _serviceProvider.GetRequiredService<frmSports>();
            frm.Text = "Deportes";
            frm.ShowDialog();
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            using var frm = _serviceProvider.GetRequiredService<frmGenres>();
            frm.Text = "Géneros";
            frm.ShowDialog();
        }

        private void btnSizes_Click(object sender, EventArgs e)
        {
            using var frm = _serviceProvider.GetRequiredService<frmSizes>();
            frm.Text = "Talles";
            frm.ShowDialog();
        }

        private void btnZapatillas_Click(object sender, EventArgs e)
        {
            using var frm = _serviceProvider.GetRequiredService<frmSportShoes>();
            frm.Text = "Zapatillas";
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
