using Worked.Application.ViewModels;

namespace Worked.Application.Interfaces
{
    public interface ITipoTarefaServices
    {
        Task<ICollection<TipoTarefaViewModel>> Listar();
        Task<TipoTarefaViewModel> ConsultarPorId(int id);
    }
}
