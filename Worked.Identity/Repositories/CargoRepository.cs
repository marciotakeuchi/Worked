using Microsoft.EntityFrameworkCore;
using Worked.Domain.Entities;
using Worked.Domain.Interfaces;
using Worked.Infra.Data;

namespace Worked.Infra.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly ApplicationDbContext _context;

        public CargoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cargo> ConsultarPorId(int id)
        {
            return await _context.Cargos.FindAsync(id);
        }

        public async Task<ICollection<Cargo>> Listar()
        {
            return await _context.Cargos.ToListAsync();
        }
    }
}
