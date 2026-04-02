using System.Configuration;
using System.Data;
using System.Windows;
using System.Globalization;
using System.Threading;

namespace MiniProjetoCadastroTarefa
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var cultura = new CultureInfo("pt-BR");

            Thread.CurrentThread.CurrentCulture = cultura;
            Thread.CurrentThread.CurrentUICulture = cultura;

            base.OnStartup(e);
        }
    }

}
