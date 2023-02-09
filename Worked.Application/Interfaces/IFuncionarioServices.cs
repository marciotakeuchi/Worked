using Worked.Application.ViewModels;

namespace Worked.Application.Interfaces
{
    public interface IFuncionarioServices
    {
        Task<ICollection<FuncionarioViewModel>> Listar();
        Task<FuncionarioViewModel> ConsultarPorId(int id);
        FuncionarioViewModel Inserir(FuncionarioViewModel funcionario);
        void Alterar(FuncionarioViewModel funcionario);
        void Excluir(int id);
    }
}
