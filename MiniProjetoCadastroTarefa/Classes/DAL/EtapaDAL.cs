using Microsoft.Data.SqlClient;
using MiniProjetoCadastroTarefa.Classes.Base;
using MiniProjetoCadastroTarefa.Classes.Generico;
using MiniProjetoCadastroTarefa.Classes.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetoCadastroTarefa.Classes.DAL
{
    public class EtapaDAL : BaseDAL
    {
        private readonly string _connectionString;

        public EtapaDAL()
        {
            _connectionString = SQLServerClass.GetConnectionString();
        }

        public async Task<List<clsModelEtapa>> ListarAsync(
            Guid tarefaId,
            string? titulo,
            bool inativo = false)
        {
            using var connection = new SqlConnection(_connectionString);

            string sql = @"
            SELECT 
                Id,
                TarefaId,
                Titulo,
                Descricao,
                DataInicio,
                DataFimPrevisto,
                DataFimReal,
                Ordem,
                Inativo
            FROM ETAPA
            WHERE TarefaId = @TarefaId
            AND (@Titulo IS NULL OR Titulo LIKE '%' + @Titulo + '%')
            AND Inativo = @Inativo
            ORDER BY Ordem";

            var resultado = await connection.QueryAsync<clsModelEtapa>(
                sql,
                new
                {
                    TarefaId = tarefaId,
                    Inativo = inativo,
                    Titulo = string.IsNullOrWhiteSpace(titulo) ? null : titulo
                });

            return resultado.ToList();
        }

        public async Task InserirAsync(clsModelEtapa etapa)
        {
            using var connection = new SqlConnection(_connectionString);

            string sql = @"
            INSERT INTO ETAPA
            (
                Id,
                TarefaId,
                Titulo,
                Descricao,
                DataInicio,
                DataFimPrevisto,
                DataFimReal,
                Ordem,
                Inativo
            )
            VALUES
            (
                @Id,
                @TarefaId,
                @Titulo,
                @Descricao,
                @DataInicio,
                @DataFimPrevisto,
                @DataFimReal,
                @Ordem,
                @Inativo
            )";

            await connection.ExecuteAsync(sql, etapa);
        }

        public async Task<clsModelEtapa?> ConsultarAsync(Guid id, bool inativo = false)
        {
            using var connection = new SqlConnection(_connectionString);

            string sql = @"
            SELECT 
                Id,
                TarefaId,
                Titulo,
                Descricao,
                DataInicio,
                DataFimPrevisto,
                DataFimReal,
                Ordem,
                Inativo
            FROM ETAPA
            WHERE Id = @Id
            AND Inativo = @Inativo";

            return await connection.QueryFirstOrDefaultAsync<clsModelEtapa>(
                sql,
                new
                {
                    Id = id,
                    Inativo = inativo
                });
        }

        public async Task AtualizarAsync(clsModelEtapa etapa)
        {
            using var connection = new SqlConnection(_connectionString);

            string sql = @"
            UPDATE ETAPA
            SET
                Titulo = @Titulo,
                Descricao = @Descricao,
                DataInicio = @DataInicio,
                DataFimPrevisto = @DataFimPrevisto,
                DataFimReal = @DataFimReal,
                Ordem = @Ordem,
                Inativo = @Inativo
            WHERE Id = @Id";

            await connection.ExecuteAsync(sql, etapa);
        }

        public async Task AlterarStatusAsync(Guid id, bool inativo)
        {
            using var connection = new SqlConnection(_connectionString);

            string sql = @"
            UPDATE ETAPA
            SET Inativo = @Inativo
            WHERE Id = @Id";

            await connection.ExecuteAsync(sql, new
            {
                Id = id,
                Inativo = inativo
            });
        }
    }
}
