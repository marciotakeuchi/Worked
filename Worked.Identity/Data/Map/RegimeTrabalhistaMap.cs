using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worked.Domain.Entities;

namespace Worked.Infra.Data.Map
{
    public class RegimeTrabalhistaMap : IEntityTypeConfiguration<RegimeTrabalhista>
    {
        public void Configure(EntityTypeBuilder<RegimeTrabalhista> builder)
        {
            builder.ToTable("RegimeTrabalhista");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnType("varchar(500)");
            builder.HasData(
                new RegimeTrabalhista(1, "Estágio"),
                new RegimeTrabalhista(2, "CLT"),
                new RegimeTrabalhista(3, "PJ")
                );
        }
    }
}
