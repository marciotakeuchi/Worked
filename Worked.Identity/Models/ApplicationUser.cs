using Microsoft.AspNetCore.Identity;
using Worked.Domain.Entities;

namespace Worked.Infra.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public int? FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
    }
}
