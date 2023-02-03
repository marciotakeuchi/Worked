using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Worked.Domain.Models;
using Worked.Infra.Data.Map;
using Worked.Infra.Models;

namespace Worked.Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //new FuncionarioMap().Configure(builder.Entity<Funcionario>());
           
            builder.ApplyConfiguration(new FuncionarioMap());
            builder.ApplyConfiguration(new TarefaMap());
            builder.ApplyConfiguration(new CargoMap());
            builder.ApplyConfiguration(new RegimeTrabalhistaMap());
            builder.ApplyConfiguration(new TipoTarefaMap());
            base.OnModelCreating(builder);
        }
        

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TipoTarefa> TipoTarefas {get;set;}
        public DbSet<RegimeTrabalhista> RegimeTrabalhistas { get; set; }



    }
}