using CleanArquitecture.Application.Models.Email;

namespace CleanArquitecture.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
