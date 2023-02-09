using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Worked.Infra.Data.Map
{
    public class AspNetUserRolesMap : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityUserRole<Guid>()
                {
                    RoleId = new Guid("C6FB1D37-CA61-4202-9BAA-0FB0455714F5"),
                    UserId = new Guid("BAFD5FE2-B9E2-461D-3254-08DB06712DE6")
                }
                );
        }
    }
}
