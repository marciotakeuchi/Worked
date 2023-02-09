using Worked.Domain.Entities;

namespace Worked.Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<ICollection<Funcionario>> Listar();
        Task<Funcionario> ConsultarPorId(int id);
        Funcionario Inserir(Funcionario funcionario);
        void Alterar(Funcionario funcionario);
        void Excluir(Funcionario funcionario);
    }
}
