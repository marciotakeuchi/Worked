using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worked.Domain.Models
{
    public class Cargo
    {
        public Cargo()
        {
        }
        public Cargo(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;    
            Descricao = descricao;
        }
        public Cargo( string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
