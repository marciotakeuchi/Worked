namespace Worked.Domain.Entities
{
    public class TipoTarefa
    {
        public TipoTarefa(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
