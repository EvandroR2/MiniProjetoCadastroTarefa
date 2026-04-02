using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetoCadastroTarefa.Classes.Generico
{
    public static class SQLServerClass
    {
        public static string GetConnectionString()
        {
            return clsConfiguracao.StringConexao;
        }
    }
}
