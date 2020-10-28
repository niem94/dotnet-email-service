using System.Threading.Tasks;

namespace EmailService.Providers
{
    public interface IEmailProvider
    {
        void CreateMail(string email, string subject, string message, bool ishtml, EmailSettings emailSettings);

        Task SendMailAsync();
        Task SendMailAsync(string username, string password);
    }
}