namespace Worked.Domain.Entities
{
    public class RegimeTrabalhista
    {
        public RegimeTrabalhista(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        public int Id { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
