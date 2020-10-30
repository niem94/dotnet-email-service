using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace EmailService.Providers.Smtp
{
    public class SmtpEmailService : EmailService<SmtpEmailSettings>
    {
        public SmtpClient SmtpClient { get; set; }
        public MailMessage MailMessage { get; set; }

        protected SmtpEmailService(IOptions<SmtpEmailSettings> options) : base(options)
        {
            SmtpClient = new SmtpClient(Settings.Host, Settings.Port);
        }
        public override async Task SendEmailAsync(string email, string subject, string message, bool isHtml)
        {
            MailMessage = new MailMessage();
            MailMessage.To.Add(new MailAddress(email));
            MailMessage.From = string.IsNullOrEmpty(Settings.Username)
                ? new MailAddress("noreply@EcosystemMapGenerator.dk")
                : new MailAddress("noreply@EcosystemMapGenerator.dk", Settings.Username);
            MailMessage.IsBodyHtml = isHtml;
            MailMessage.Subject = subject;
            MailMessage.Body = message;
            SmtpClient.Timeout = 10000;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = false;
            await SmtpClient.SendMailAsync(MailMessage).ConfigureAwait(false);
            SmtpClient.Dispose();
        }
    }
}
