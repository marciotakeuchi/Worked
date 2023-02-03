using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worked.Domain.Models
{
    public class TipoTarefa
    {

        public TipoTarefa() { }
        public TipoTarefa(int id, int descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        public TipoTarefa( int descricao)
        {
            Descricao = descricao;
        }

        public int Id { get; set; }
        public int Descricao { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
