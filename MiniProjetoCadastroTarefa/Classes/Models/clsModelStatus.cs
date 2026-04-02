using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetoCadastroTarefa.Classes.Models
{
    public class clsModelStatus
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<clsModelTarefa> Tarefas { get; set; }
            = new List<clsModelTarefa>();
    }
}
