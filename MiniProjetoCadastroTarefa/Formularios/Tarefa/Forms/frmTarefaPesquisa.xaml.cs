using MiniProjetoCadastroTarefa.Classes.ClsTipos;
using MiniProjetoCadastroTarefa.Classes.Models;
using MiniProjetoCadastroTarefa.Classes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiniProjetoCadastroTarefa.Formularios.Tarefa.Forms
{
    /// <summary>
    /// Lógica interna para FrmTarefaPesquisa.xaml
    /// </summary>
    public partial class FrmTarefaPesquisa : Window
    {
        public FrmTarefaPesquisa()
        {
            InitializeComponent();

            var vm = new clsTarefaPesquisaViewModel();

            vm.AbrirCadastro += Vm_AbrirCadastro;

            DataContext = vm;
        }

        private void Vm_AbrirCadastro(
            clsModelTarefa tarefa,
            clsTiposEnumerados.AcaoFormulario acao)
        {
            var frm = new FrmTarefaCadastro(acao, tarefa);
            frm.ShowDialog();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is clsTarefaPesquisaViewModel vm
                && vm.TarefaSelecionada != null)
            {
                vm.AlterarCommand.Execute(null);
            }
        }

        private void cmdSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
