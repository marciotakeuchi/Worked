using Microsoft.EntityFrameworkCore;
using Worked.Domain.Entities;
using Worked.Domain.Interfaces;
using Worked.Infra.Data;

namespace Worked.Infra.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private ApplicationDbContext _context;
        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Funcionario> ConsultarPorId(int id)
        {
            return await _context.Funcionarios.FindAsync(id);
        }
        public async Task<ICollection<Funcionario>> Listar()
        {
            return await _context.Funcionarios.ToListAsync();
        }
        public Funcionario Inserir(Funcionario funcionario)
        {
            _context.Add(funcionario);
            _context.SaveChanges();
            return funcionario;
        }
        public void Alterar(Funcionario funcionario)
        {
            _context.Update(funcionario);
            _context.SaveChanges();
        }
        public void Excluir(Funcionario funcionario)
        {
            _context.Remove(funcionario);
            _context.SaveChanges();
        }
    }
}
