using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worked.Domain.Models
{
    public class RegimeTrabalhista
    {
        public RegimeTrabalhista()
        {

        }

        public RegimeTrabalhista(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        public RegimeTrabalhista(string descricao)
        {
            Descricao = descricao;
        }

        public int Id { get; set; }

        public string Descricao { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
