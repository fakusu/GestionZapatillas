using GestionZapatillas.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace GestionZapatillas.Windows
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            services.AddApplicationServices();

            // Registrar todos los Forms automáticamente
            var formularios = typeof(Program).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Form)) && !t.IsAbstract)
                .ToList();
            foreach (var frm in formularios)
                services.AddTransient(frm);

            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<frmPrincipal>());
        }
    }
}
