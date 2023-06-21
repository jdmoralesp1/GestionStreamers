using CleanArquitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArquitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "189fa1b6-4bad-4d32-b44b-3fe602f82a34",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Juan",
                    Apellidos = "Morales",
                    UserName = "juanmorales",
                    NormalizedUserName = "juanmorales",
                    PasswordHash = hasher.HashPassword(null, "Control2022."),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "0c4b1061-52cb-48dd-9b9e-cc88a24ab0cd",
                    Email = "juanperez@localhost.com",
                    NormalizedEmail = "juanperez@localhost.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "juanperez",
                    NormalizedUserName = "juanperez",
                    PasswordHash = hasher.HashPassword(null, "Control2022."),
                    EmailConfirmed = true,
                }
            );
        }
    }
}
