using CleanOnionNetwork.Application.Models;

namespace CleanOnionNetwork.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
