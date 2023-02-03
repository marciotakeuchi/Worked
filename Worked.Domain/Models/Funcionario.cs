using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worked.Domain.Models
{
    public class Funcionario
    {
        public Funcionario()
        {

        }

        public Funcionario(int id, string nome, string cpf, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Funcionario? Gestor { get; set; }
        public RegimeTrabalhista RegimeTrabalhista { get; set; }
        public Cargo Cargo { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
