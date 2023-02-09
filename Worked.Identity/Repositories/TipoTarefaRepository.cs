using Microsoft.EntityFrameworkCore;
using Worked.Domain.Entities;
using Worked.Domain.Interfaces;
using Worked.Infra.Data;

namespace Worked.Infra.Repositories
{
    public class TipoTarefaRepository : ITipoTarefaRepository
    {

        private readonly ApplicationDbContext _context;

        public TipoTarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TipoTarefa> ConsultarPorId(int id)
        {
            return await _context.TipoTarefas.FindAsync(id);
        }

        public async Task<ICollection<TipoTarefa>> Listar()
        {
            return await _context.TipoTarefas.ToListAsync();
        }
    }
}
