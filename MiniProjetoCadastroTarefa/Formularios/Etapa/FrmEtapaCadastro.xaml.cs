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

namespace MiniProjetoCadastroTarefa.Formularios.Etapa
{
    /// <summary>
    /// Lógica interna para FrmEtapaCadastro.xaml
    /// </summary>
    public partial class FrmEtapaCadastro : Window
    {
        public FrmEtapaCadastro(Guid tarefaId, clsModelEtapa? etapa = null)
        {
            InitializeComponent();

            var vm = new EtapaCadastroViewModel(tarefaId, etapa);

            vm.FecharTela += () => this.Close();

            DataContext = vm;
        }
    }
}
