using System.Net.Mail;
using System.Threading.Tasks;
using EmailService.Models;
using Microsoft.Extensions.Options;

namespace EmailService.Smtp
{
    public class SmtpEmailService : EmailService<SmtpSettings>
    {
        public SmtpClient SmtpClient { get; set; }

        protected SmtpEmailService(IOptions<SmtpSettings> options) : base(options)
        {
            SmtpClient = new SmtpClient(Settings.Host, Settings.Port);
        }
        public override async Task SendEmailAsync(EmailMessage message)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(message.FromAdress, message.FromName),
                IsBodyHtml = message.IsHtml,
                Subject = message.Subject,
                Body = message.Body
            };
            mailMessage.To.Add(new MailAddress(message.ToAddress, message.ToName));
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = Settings.UseDefaultCredentials;
            await SmtpClient.SendMailAsync(mailMessage).ConfigureAwait(false);
            SmtpClient.Dispose();
        }
    }
}
