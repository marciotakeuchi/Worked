using Microsoft.EntityFrameworkCore;
using Worked.Domain.Entities;
using Worked.Domain.Interfaces;
using Worked.Infra.Data;

namespace Worked.Infra.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _context;

        public TarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> ConsultarPorId(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }
        public async Task<ICollection<Tarefa>> Listar()
        {
            return await _context.Tarefas.ToListAsync();
        }
        public void Inserir(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
        }
        public void Alterar(Tarefa tarefa)
        {
            _context.Update(tarefa);
            _context.SaveChanges();
        }
        public void Excluir(Tarefa tarefa)
        {
            _context.Remove(tarefa);
            _context.SaveChanges();
        }
    }
}
