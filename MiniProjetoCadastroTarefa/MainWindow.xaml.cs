using MiniProjetoCadastroTarefa.Classes.Generico;
using MiniProjetoCadastroTarefa.Formularios.Tarefa.Forms;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniProjetoCadastroTarefa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                clsConfiguracao.Carregar();

                MessageBox.Show("Configuração carregada com sucesso!");
                //                $"Conexão: {clsConfiguracao.StringConexao}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Configuração", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown(); // Fecha o app se não conseguir carregar config
            }
        }
        
        private void btnCadTarefas_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AbrirTarefas_Click(object sender, RoutedEventArgs e)
        {
            FrmTarefaPesquisa f = new FrmTarefaPesquisa();
            f.Show();
            this.Close();
        }
    }
}