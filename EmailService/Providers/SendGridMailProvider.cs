using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailService.Providers
{
    public class SendGridEmailProvider : IEmailProvider
    {
        public SendGridEmailProvider(string apiKey)
        {
            SendGridClient = new SendGridClient(apiKey);
            SendGridMessage = new SendGridMessage();
        }

        public SendGridClient SendGridClient { get; set; }
        public SendGridMessage SendGridMessage { get; set; }

        public void CreateMail(string email, string subject, string message, bool ishtml, EmailSettings emailSettings)
        {
            SendGridMessage.From = string.IsNullOrEmpty(emailSettings.Username)
                ? new EmailAddress($"noreply@{emailSettings.Host}")
                : new EmailAddress($"noreply@{emailSettings.Host}", emailSettings.Username);
            SendGridMessage.Subject = subject;
            SendGridMessage.PlainTextContent = message;
            SendGridMessage.HtmlContent = message;
            SendGridMessage.AddTo(new EmailAddress(email));
            SendGridMessage.SetClickTracking(false, false);
        }

        public async Task SendMailAsync()
        {
            await SendGridClient.SendEmailAsync(SendGridMessage).ConfigureAwait(false);
        }

        public async Task SendMailAsync(string username, string password)
        {
            await SendMailAsync().ConfigureAwait(false);
        }
    }
}
