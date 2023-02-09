using Worked.Domain.Entities;

namespace Worked.Domain.Interfaces
{
    public interface IRegimeTrabalhistaRepository
    {
        Task<ICollection<RegimeTrabalhista>> Listar();
        Task<RegimeTrabalhista> ConsultarPorId(int id);
    }
}
