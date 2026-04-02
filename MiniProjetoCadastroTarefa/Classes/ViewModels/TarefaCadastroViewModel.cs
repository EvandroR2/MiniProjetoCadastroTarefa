using MiniProjetoCadastroTarefa.Classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MiniProjetoCadastroTarefa.Classes.Base;
using MiniProjetoCadastroTarefa.Classes.Service;
using MiniProjetoCadastroTarefa.Formularios.Etapa;


namespace MiniProjetoCadastroTarefa.Classes.ViewModels
{
    public class TarefaCadastroViewModel : ViewModelBase
    {
        private readonly EtapaService _etapaService;

        public clsModelTarefa Tarefa { get; set; }

        public ObservableCollection<clsModelEtapa> ListaEtapas { get; set; }

        private clsModelEtapa? _etapaSelecionada;
        public clsModelEtapa? EtapaSelecionada
        {
            get => _etapaSelecionada;
            set
            {
                _etapaSelecionada = value;
                OnPropertyChanged();
            }
        }
        private int _abaSelecionada;
        public int AbaSelecionada
        {
            get => _abaSelecionada;
            set
            {
                _abaSelecionada = value;
                OnPropertyChanged();

                if (_abaSelecionada == 1) // índice da aba Etapas
                {
                    _ = CarregarEtapas();
                }
            }

        }


        private string? _filtroDescricaoEtapa;
        public string? FiltroDescricaoEtapa
        {
            get => _filtroDescricaoEtapa;
            set
            {
                _filtroDescricaoEtapa = value;
                OnPropertyChanged();

                _ = CarregarEtapas();
            }
        }

        private bool _mostrarInativoEtapa;
        public bool MostrarInativoEtapa
        {
            get => _mostrarInativoEtapa;
            set
            {
                _mostrarInativoEtapa = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConsultarEtapaCommand { get; }
        public ICommand AdicionarEtapaCommand { get; }
        public ICommand AlterarEtapaCommand { get; }
        public ICommand RemoverEtapaCommand { get; }

        public TarefaCadastroViewModel(clsModelTarefa tarefa)
        {
            _etapaService = new EtapaService();

            Tarefa = tarefa;

            ListaEtapas = new ObservableCollection<clsModelEtapa>();

            ConsultarEtapaCommand = new RelayCommand(async _ => await CarregarEtapas());
            AdicionarEtapaCommand = new RelayCommand(AdicionarEtapa);
            AlterarEtapaCommand = new RelayCommand(AlterarEtapa, _ => EtapaSelecionada != null);
            RemoverEtapaCommand = new RelayCommand(RemoverEtapa, _ => EtapaSelecionada != null);
        }

        private async Task CarregarEtapas()
        {
            if (Tarefa == null)
                return;

            ListaEtapas.Clear();

            var lista = await _etapaService.ListarAsync(
                Tarefa.Id,
                FiltroDescricaoEtapa,
                MostrarInativoEtapa);

            foreach (var item in lista)
                ListaEtapas.Add(item);
        }

        private async void AdicionarEtapa(object? obj)
        {
            var frm = new FrmEtapaCadastro(Tarefa.Id);
            frm.ShowDialog();

            await CarregarEtapas();
        }

        private void AlterarEtapa(object? obj)
        {
            if (EtapaSelecionada == null)
                return;

            var frm = new FrmEtapaCadastro(Tarefa.Id, EtapaSelecionada);
            frm.ShowDialog();

            _ = CarregarEtapas();
        }

        private async void RemoverEtapa(object? obj)
        {
            if (EtapaSelecionada == null)
                return;

            await _etapaService.AlterarStatusAsync(
                EtapaSelecionada.Id,
                true);

            await CarregarEtapas();
        }
    }
}
