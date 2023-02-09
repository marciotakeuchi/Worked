using Worked.Domain.Entities;

namespace Worked.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<ICollection<Tarefa>> Listar();
        Task<Tarefa> ConsultarPorId(int id);
        void Inserir(Tarefa tarefa);
        void Alterar(Tarefa tarefa);
        void Excluir(Tarefa tarefa);
    }
}
