using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worked.Domain.Entities;

namespace Worked.Infra.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataTarefa).HasColumnType("Date");
            builder.Property(x => x.HoraInicio).HasColumnType("Time");
            builder.Property(x => x.HoraTermino).HasColumnType("Time");
            builder.Property(x => x.TotalHoras).HasColumnType("Time");
            builder.Property(x => x.Descricao).HasColumnType("varchar(2000)");
            builder.Property(x => x.DataRegistro).HasColumnType("Datetime");
            builder.HasOne(x => x.TipoTarefa);
            builder.HasOne(x => x.Funcionario);
        }
    }
}
