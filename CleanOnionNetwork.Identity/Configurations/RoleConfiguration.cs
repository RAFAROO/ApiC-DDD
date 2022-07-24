using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanOnionNetwork.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "24e486f7-b80b-472d-b7aa-4ae6140a1542",
                    Name= "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole
                {
                    Id = "c17cd9c3-0294-4c07-8e0c-ca4b62239553",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                }
            );
        }
    }
}
