using Worked.Application.ViewModels;

namespace Worked.Application.Interfaces
{
    public interface ITarefaServices
    {
        Task<ICollection<TarefaViewModel>> Listar();
        Task<TarefaViewModel> ConsultarPorId(int id);
        void Inserir(TarefaViewModel tarefa);
        void Alterar(TarefaViewModel tarefa);
        void Excluir(int id);
    }
}
