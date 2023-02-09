using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worked.Infra.Models;

namespace Worked.Infra.Data.Map
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
             new ApplicationUser()
             {
                 Id = new Guid("BAFD5FE2-B9E2-461D-3254-08DB06712DE6"),
                 UserName = "admin@admin.com",
                 NormalizedUserName = "ADMIN@ADMIN.COM",
                 Email = "admin@admin.com",
                 NormalizedEmail = "ADMIN@ADMIN.COM",
                 EmailConfirmed = false,
                 PasswordHash = "AQAAAAEAACcQAAAAEPYZ5UVCzSkt2f1iwr5DxO1MSNFBkOhQgUl4xOxhhWPEDbv/e2SPqjEb5Yvwmkww3g==",
                 SecurityStamp = "366JHU5SPKAVGFJTQW6WMHADSCJMZ7NP",
                 ConcurrencyStamp = "0ad875b5-b7e0-4221-aaf3-34f049f83ace",
                 PhoneNumberConfirmed = false,
                 TwoFactorEnabled = false,
                 LockoutEnabled = true,
                 AccessFailedCount = 0,
                 FuncionarioId = 1
             }
             );
        }
    }
}
