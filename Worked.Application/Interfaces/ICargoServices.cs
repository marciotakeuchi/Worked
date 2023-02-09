using Worked.Application.ViewModels;

namespace Worked.Application.Interfaces
{
    public interface ICargoServices
    {
        Task<ICollection<CargoViewModel>> Listar();
        Task<CargoViewModel> ConsultarPorId(int id);
    }
}
