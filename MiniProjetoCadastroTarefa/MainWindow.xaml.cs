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
            PreencherComboFormulario();
        }

        private void cmbFormulario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFormulario.SelectedItem is Classes.ClsTipos.clsTiposEnumerados.Formulario formularioSelecionado)
            {
                Window janela = formularioSelecionado switch
                {
                    Classes.ClsTipos.clsTiposEnumerados.Formulario.Tarefas => new FrmTarefaPesquisa(),
                    Classes.ClsTipos.clsTiposEnumerados.Formulario.TarefasCad => new FrmTarefaCadastro(Classes.ClsTipos.clsTiposEnumerados.AcaoFormulario.Incluir),
                    _ => throw new NotImplementedException()
                };

                cmbFormulario.SelectedIndex = -1;
                janela?.Show();
            }
        }
        private void PreencherComboFormulario()
        {
            foreach (var form in Enum.GetValues(typeof(Classes.ClsTipos.clsTiposEnumerados.Formulario)))
            {
                cmbFormulario.Items.Add(form);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                clsConfiguracao.Carregar();

                MessageBox.Show("Configuração carregada com sucesso!\n" +
                                $"Conexão: {clsConfiguracao.StringConexao}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Configuração", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown(); // Fecha o app se não conseguir carregar config
            }
        }
        
        private void btnCadTarefas_Click(object sender, RoutedEventArgs e)
        {
            FrmTarefaPesquisa f = new FrmTarefaPesquisa();
            f.Show();
            this.Close();
        }
    }
}