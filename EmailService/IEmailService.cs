using System.Threading.Tasks;
using EmailService.Models;

namespace EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage message);
    }
}