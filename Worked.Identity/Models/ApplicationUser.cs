using Microsoft.AspNetCore.Identity;
using Worked.Domain.Models;

namespace Worked.Infra.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public Funcionario? Funcionario { get; set; }
    }
}
