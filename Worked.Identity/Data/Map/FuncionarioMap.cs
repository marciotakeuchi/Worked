using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worked.Domain.Models;

namespace Worked.Infra.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(250)");
            builder.Property(x => x.Cpf).HasColumnType("varchar(11)");
            builder.Property(x => x.DataNascimento).HasColumnType("Date");
            builder.Property(x => x.Email).HasColumnType("varchar(300)");
            builder.Property(x => x.Telefone).HasColumnType("varchar(20)");
            builder.HasOne(x => x.Gestor);
            builder.HasOne(x => x.RegimeTrabalhista);
            builder.HasOne(x => x.Cargo);
            builder.HasMany(x => x.Tarefas);
        }
    }
}
