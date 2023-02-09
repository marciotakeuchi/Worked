using Worked.Domain.Entities;

namespace Worked.Domain.Interfaces
{
    public interface ITipoTarefaRepository
    {
        Task<ICollection<TipoTarefa>> Listar();
        Task<TipoTarefa> ConsultarPorId(int id);
    }
}
