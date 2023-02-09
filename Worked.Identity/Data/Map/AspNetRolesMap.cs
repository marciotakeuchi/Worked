using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Worked.Infra.Data.Map
{
    public class AspNetRolesMap : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityRole<Guid>()
                {
                    Id = new Guid("C6FB1D37-CA61-4202-9BAA-0FB0455714F5"),
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = null
                }
            );
        }

    }


}
