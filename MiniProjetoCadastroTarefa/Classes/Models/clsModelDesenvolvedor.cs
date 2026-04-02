using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetoCadastroTarefa.Classes.Models
{
    public class clsModelDesenvolvedor
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public virtual ICollection<clsModelTarefa> Desevolvedor { get; set; }
            = new List<clsModelTarefa>();
    }
}
