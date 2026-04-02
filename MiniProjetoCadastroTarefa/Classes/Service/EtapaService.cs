using MiniProjetoCadastroTarefa.Classes.DAL;
using MiniProjetoCadastroTarefa.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetoCadastroTarefa.Classes.Service
{
    public class EtapaService
    {
        private readonly EtapaDAL _dal;

        public EtapaService()
        {
            _dal = new EtapaDAL();
        }

        public async Task<List<clsModelEtapa>> ListarAsync(
            Guid tarefaId,
            string? titulo,
            bool inativo = false)
        {
            return await _dal.ListarAsync(tarefaId, titulo, inativo);
        }

        public async Task<clsModelEtapa?> ConsultarAsync(Guid id, bool inativo = false)
        {
            return await _dal.ConsultarAsync(id, inativo);
        }

        public async Task InserirAsync(clsModelEtapa etapa)
        {
            ValidarEtapa(etapa);

            etapa.Id = Guid.NewGuid();

            await _dal.InserirAsync(etapa);
        }

        public async Task AtualizarAsync(clsModelEtapa etapa)
        {
            ValidarEtapa(etapa);

            await _dal.AtualizarAsync(etapa);
        }

        public async Task AlterarStatusAsync(Guid id, bool inativo)
        {
            await _dal.AlterarStatusAsync(id, inativo);
        }

        private void ValidarEtapa(clsModelEtapa etapa)
        {
            if (etapa.TarefaId == Guid.Empty)
                throw new Exception("Tarefa não informada.");

            if (string.IsNullOrWhiteSpace(etapa.Titulo))
                throw new Exception("Título é obrigatório.");

            if (etapa.DataFimPrevisto.HasValue &&
                etapa.DataFimPrevisto < etapa.DataInicio)
                throw new Exception("Data fim previsto não pode ser menor que data início.");
        }
    }
}
