using MiniProjetoCadastroTarefa.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetoCadastroTarefa.Classes.ClsTipos
{
    public static class StatusHelper
    {
        public static List<clsModelStatus> ObterStatus()
        {
            return new List<clsModelStatus>
        {
            new clsModelStatus { Id = 1, Nome = "Pendente" },
            new clsModelStatus { Id = 2, Nome = "Em Andamento" },
            new clsModelStatus { Id = 3, Nome = "Concluída" },
            new clsModelStatus { Id = 4, Nome = "Cancelada" }
        };
        }
    }
}
