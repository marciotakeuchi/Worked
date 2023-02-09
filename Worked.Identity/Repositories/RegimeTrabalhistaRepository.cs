using Microsoft.EntityFrameworkCore;
using Worked.Domain.Entities;
using Worked.Domain.Interfaces;
using Worked.Infra.Data;

namespace Worked.Infra.Repositories
{
    public class RegimeTrabalhistaRepository : IRegimeTrabalhistaRepository
    {
        private readonly ApplicationDbContext _context;
        public RegimeTrabalhistaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegimeTrabalhista> ConsultarPorId(int id)
        {
            return await _context.RegimeTrabalhistas.FindAsync(id);
        }

        public async Task<ICollection<RegimeTrabalhista>> Listar()
        {
            return await _context.RegimeTrabalhistas.ToListAsync();
        }


    }
}
