namespace Worked.Domain.Entities
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int? GestorId { get; set; }
        public virtual Funcionario? Gestor { get; set; }
        public int RegimeTrabalhistaId { get; set; }
        public virtual RegimeTrabalhista RegimeTrabalhista { get; set; }
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }


    }
}
