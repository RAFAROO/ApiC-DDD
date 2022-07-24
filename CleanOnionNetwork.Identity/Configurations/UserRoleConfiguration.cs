using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanOnionNetwork.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "24e486f7-b80b-472d-b7aa-4ae6140a1542",
                    UserId = "548cc02e-8561-424c-b347-f81b81f0a0fe"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c17cd9c3-0294-4c07-8e0c-ca4b62239553",
                    UserId = "d151a7fc-9913-4e1d-a642-74cf94c200c0"
                }
            );
        }
    }
}
