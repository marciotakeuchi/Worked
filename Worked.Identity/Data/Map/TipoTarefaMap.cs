using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worked.Domain.Entities;

namespace Worked.Infra.Data.Map
{
    public class TipoTarefaMap : IEntityTypeConfiguration<TipoTarefa>
    {
        public void Configure(EntityTypeBuilder<TipoTarefa> builder)
        {
            builder.ToTable("TipoTarefa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnType("varchar(500)");
            builder.HasData(
                new TipoTarefa(1, "Projeto"),
                new TipoTarefa(2, "Atendimento Cliente"),
                new TipoTarefa(3, "Reuniões")
                );
        }
    }
}
