using CleanOnionNetwork.Application.Contracts.Infrastructure;
using CleanOnionNetwork.Application.Contracts.Persistence;
using CleanOnionNetwork.Application.Models;
using CleanOnionNetwork.Infrastructure.Email;
using CleanOnionNetwork.Infrastructure.Persistence;
using CleanOnionNetwork.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanOnionNetwork.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StreamerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings"))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IStreamerRepository, StreamerRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
