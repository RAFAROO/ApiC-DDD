using CleanOnionNetwork.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanOnionNetwork.Identity.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "548cc02e-8561-424c-b347-f81b81f0a0fe",
                        Email = "admin@network.com",
                        NormalizedEmail = "admin@network.com",
                        Nombre = "Rafael",
                        Apellidos = "Olivares",
                        UserName = "roo",
                        NormalizedUserName = "roo",
                        PasswordHash = hasher.HashPassword(null, "Roo.865"),
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "d151a7fc-9913-4e1d-a642-74cf94c200c0",
                        Email = "user@network.com",
                        NormalizedEmail = "user@network.com",
                        Nombre = "Rafael User",
                        Apellidos = "Olivares",
                        UserName = "roouser",
                        NormalizedUserName = "roouser",
                        PasswordHash = hasher.HashPassword(null, "Roouser.865"),
                        EmailConfirmed = true
                    }
                ); 
        }
    }
}
