using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worked.Domain.Models;

namespace Worked.Infra.Data.Map
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("Cargo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(150)");
            builder.Property(x => x.Descricao).HasColumnType("varchar(500)");
            builder.HasMany(x => x.Funcionarios);

            builder.HasData(
                new Cargo(1,"Estagiário", "Cursando ensino de graduação ou tecnólogo."),
                new Cargo(2,"Analista", "Graduado em ensino superior."),
                new Cargo(3,"Gerente", "Graduado em ensino superior com experiência maior de 5 anos na área de atuação.")
                ); 
        }
    }
}
