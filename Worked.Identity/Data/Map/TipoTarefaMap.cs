using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worked.Domain.Models;

namespace Worked.Infra.Data.Map
{
    public class TipoTarefaMap : IEntityTypeConfiguration<TipoTarefa>
    {
        public void Configure(EntityTypeBuilder<TipoTarefa> builder)
        {
            builder.ToTable("TipoTarefa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnType("varchar(500)");
            builder.HasMany(x => x.Tarefas);
        }
    }
}
