using System.Threading.Tasks;
using EmailService.Providers;
using Microsoft.Extensions.Options;

namespace EmailService
{
    public class EmailService : IEmailService
    {
        public EmailService(IOptions<EmailSettings> optionsAccessor)
        {
            EmailSettings = optionsAccessor.Value;
        }

        private EmailSettings EmailSettings { get; }

        public async Task SendEmailAsync(string email, string subject, string message, bool isHtml)
        {
            var provider = GetMailProvider();

            provider.CreateMail(email, subject, message, isHtml, EmailSettings);

            if (!(string.IsNullOrEmpty(EmailSettings.Username) && string.IsNullOrEmpty(EmailSettings.Password)))
                await Task.Run(() => provider.SendMailAsync(EmailSettings.Username, EmailSettings.Password)).ConfigureAwait(false);
            else
                await Task.Run(() => provider.SendMailAsync()).ConfigureAwait(false);
        }

        public IEmailProvider GetMailProvider()
        {
            if (EmailSettings.Type.Equals("sendgrid", System.StringComparison.OrdinalIgnoreCase))
                return new SendGridEmailProvider(EmailSettings.Password);
            return new SmtpEmailProvider(EmailSettings.Host, EmailSettings.Port);
        }
    }
}
