using CleanOnionNetwork.Identity.Configurations;
using CleanOnionNetwork.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanOnionNetwork.Identity
{
    public class ClenArquitectureIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ClenArquitectureIdentityDbContext(DbContextOptions<ClenArquitectureIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
