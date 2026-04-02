using MiniProjetoCadastroTarefa.Classes.Base;
using MiniProjetoCadastroTarefa.Classes.ClsTipos;
using MiniProjetoCadastroTarefa.Classes.Models;
using MiniProjetoCadastroTarefa.Classes.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniProjetoCadastroTarefa.Classes.ViewModels
{
    public class clsTarefaPesquisaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<clsModelTarefa> ListaTarefas { get; set; }
            = new ObservableCollection<clsModelTarefa>();

        public event Action<clsModelTarefa, clsTiposEnumerados.AcaoFormulario> AbrirCadastro;

        

        private clsModelTarefa _tarefaSelecionada;
        public clsModelTarefa TarefaSelecionada
        {
            get => _tarefaSelecionada;
            set
            {
                _tarefaSelecionada = value;
                OnPropertyChanged();
            }
        }

        public clsTarefaPesquisaViewModel()
        {
            _service = new TarefaService();

            PesquisarCommand = new RelayCommand(Pesquisar);
            IncluirCommand = new RelayCommand(Incluir);
            AlterarCommand = new RelayCommand(Alterar, PodeAlterarExcluir);
            ExcluirCommand = new RelayCommand(Excluir, PodeAlterarExcluir);

            CarregarTarefas();
        }

        private string _filtroTitulo;
        public string FiltroTitulo
        {
            get => _filtroTitulo;
            set
            {
                _filtroTitulo = value;
                OnPropertyChanged();
            }
        }

        public ICommand PesquisarCommand { get; }
        public ICommand IncluirCommand { get; }
        public ICommand AlterarCommand { get; }
        public ICommand ExcluirCommand { get; }

        private readonly TarefaService _service;

        private bool _procurarInativo;
        public bool ProcurarInativo
        {
            get => _procurarInativo;
            set
            {
                _procurarInativo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TextoCheckBox));
                Pesquisar(null);
            }
        }

        public string TextoCheckBox
    => ProcurarInativo ? "Procurar Inativo" : "Procurar Ativo";

        private void CarregarTarefas()
        {

        }

        private async void Pesquisar(object obj)
        {
            ListaTarefas.Clear();

            var lista = await _service.ListarAsync(FiltroTitulo, ProcurarInativo);

            foreach (var item in lista)
                ListaTarefas.Add(item);
        }

        private void Incluir(object obj)
        {
            AbrirCadastro?.Invoke(null, clsTiposEnumerados.AcaoFormulario.Incluir);
        }
        private void Alterar(object obj)
        {
            if (TarefaSelecionada == null) return;

            AbrirCadastro?.Invoke(
                TarefaSelecionada,
                clsTiposEnumerados.AcaoFormulario.Alterar);
        }

        private void Excluir(object obj)
        {
            if (TarefaSelecionada == null) return;

            AbrirCadastro?.Invoke(
                TarefaSelecionada,
                clsTiposEnumerados.AcaoFormulario.Excluir);
        }


        private bool PodeAlterarExcluir(object obj)
        {
            return TarefaSelecionada != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
