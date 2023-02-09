using Worked.Domain.Entities;

namespace Worked.Domain.Interfaces
{
    public interface ICargoRepository
    {
        Task<ICollection<Cargo>> Listar();
        Task<Cargo> ConsultarPorId(int id);
    }
}
