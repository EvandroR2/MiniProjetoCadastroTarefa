using MiniProjetoCadastroTarefa.Classes.Base;
using MiniProjetoCadastroTarefa.Classes.Models;
using MiniProjetoCadastroTarefa.Classes.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniProjetoCadastroTarefa.Classes.ViewModels
{
    public class EtapaCadastroViewModel : ViewModelBase
    {
        private readonly EtapaService _service;

        public clsModelEtapa Etapa { get; set; }

        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; }

        public event Action? FecharTela;

        public EtapaCadastroViewModel(Guid tarefaId, clsModelEtapa? etapa = null)
        {
            _service = new EtapaService();

            Etapa = etapa ?? new clsModelEtapa
            {
                Id = Guid.Empty,
                TarefaId = tarefaId,
                DataInicio = DateTime.Today,
                Inativo = false
            };

            SalvarCommand = new RelayCommand(async _ => await Salvar());
            CancelarCommand = new RelayCommand(_ => FecharTela?.Invoke());
        }

        private async Task Salvar()
        {
            if (Etapa.Id == Guid.Empty)
                await _service.InserirAsync(Etapa);
            else
                await _service.AtualizarAsync(Etapa);

            FecharTela?.Invoke();
        }
    }
}
