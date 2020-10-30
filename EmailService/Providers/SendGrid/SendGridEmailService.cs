using System.Threading.Tasks;
using EmailService;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailService.Providers.SendGrid
{
    public class SendGridEmailService : EmailService<SendGridEmailSettings>
    {

        public SendGridClient SendGridClient { get; set; }
        public SendGridMessage SendGridMessage { get; set; }

        protected SendGridEmailService(IOptions<SendGridEmailSettings> options) : base(options)
        {
            SendGridClient = new SendGridClient(Settings.ApiKey);
            SendGridMessage = new SendGridMessage();
        }

        public override async Task SendEmailAsync(string email, string subject, string message, bool isHtml)
        {
            SendGridMessage.From = string.IsNullOrEmpty(Settings.Username)
                ? new EmailAddress($"noreply@{Settings.Host}")
                : new EmailAddress($"noreply@{Settings.Host}", Settings.Username);
            SendGridMessage.Subject = subject;
            SendGridMessage.PlainTextContent = message;
            SendGridMessage.HtmlContent = message;
            SendGridMessage.AddTo(new EmailAddress(email));
            SendGridMessage.SetClickTracking(false, false);
            await SendGridClient.SendEmailAsync(SendGridMessage).ConfigureAwait(false);
        }
    }
}