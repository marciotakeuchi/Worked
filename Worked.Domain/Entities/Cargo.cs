namespace Worked.Domain.Entities
{
    public class Cargo
    {
        public Cargo(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
