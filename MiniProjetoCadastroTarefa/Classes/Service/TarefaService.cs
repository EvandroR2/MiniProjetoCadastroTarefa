using MiniProjetoCadastroTarefa.Classes.DAL;
using MiniProjetoCadastroTarefa.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetoCadastroTarefa.Classes.Service
{
    public class TarefaService
    {
        private readonly TarefaDAL _dal;

        public TarefaService()
        {
            _dal = new TarefaDAL();
        }
        public async Task<Guid> InserirAsync(clsModelTarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            tarefa.DataCriacao = DateTime.Now;
            tarefa.DataAtualizacao = DateTime.Now;
            tarefa.Inativo = false;

            await _dal.InserirAsync(tarefa);

            return tarefa.Id;
        }

        public async Task<IEnumerable<clsModelTarefa>> ListarAsync(string filtroTitulo,bool procurarInativo)
        {
            return await _dal.ListarAsync(filtroTitulo, procurarInativo);
        }
        public async Task AtualizarAsync(clsModelTarefa tarefa)
        {
            tarefa.DataAtualizacao = DateTime.Now;
            await _dal.AtualizarAsync(tarefa);
        }
        public async Task<clsModelTarefa?> ConsultarTarefa(Guid guid, bool inativo = false)
        {
            return await _dal.ConsultarTarefaAsync(guid,inativo);
        }
        public async Task AlterarStatusAsync(Guid id, bool inativo)
        {
            await _dal.AlterarStatusAsync(id, inativo);
        }

    }


}
