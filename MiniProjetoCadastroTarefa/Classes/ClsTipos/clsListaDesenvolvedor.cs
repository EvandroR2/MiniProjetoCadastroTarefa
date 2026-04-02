using MiniProjetoCadastroTarefa.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetoCadastroTarefa.Classes.ClsTipos
{
    public static class clsListaDesenvolvedor
    {
        public static List<clsModelDesenvolvedor> ObterDesenvolvedor()
        {
            return new List<clsModelDesenvolvedor>
        {
            new clsModelDesenvolvedor { Id = 1, Nome = "Evandro" }
        };
        }
    }
}
