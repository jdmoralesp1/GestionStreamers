using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "50f94637-02dc-473d-9569-a367e9f46ae1",
                    UserId = "189fa1b6-4bad-4d32-b44b-3fe602f82a34"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "ea2092af-aeab-41c3-9614-b2ddf82baf96",
                    UserId = "0c4b1061-52cb-48dd-9b9e-cc88a24ab0cd"
                }
            );
        }
    }
}
