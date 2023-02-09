using Worked.Application.ViewModels;

namespace Worked.Application.Interfaces
{
    public interface IRegimeTrabalhistaServices
    {
        Task<ICollection<RegimeTrabalhistaViewModel>> Listar();
        Task<RegimeTrabalhistaViewModel> ConsultarPorId(int id);
    }
}
