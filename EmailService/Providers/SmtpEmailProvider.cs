using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailService.Providers
{
    public class SmtpEmailProvider : IEmailProvider
    {
        public SmtpEmailProvider(string host, int port)
        {
            SmtpClient = new SmtpClient(host, port);
        }

        public SmtpClient SmtpClient { get; set; }
        public MailMessage MailMessage { get; set; }

        public void CreateMail(string email, string subject, string message, bool isHtml, EmailSettings emailSettings)
        {
            MailMessage = new MailMessage();
            MailMessage.To.Add(new MailAddress(email));
            MailMessage.From = string.IsNullOrEmpty(emailSettings.Username)
                ? new MailAddress("noreply@EcosystemMapGenerator.dk")
                : new MailAddress("noreply@EcosystemMapGenerator.dk", emailSettings.Username);
            MailMessage.IsBodyHtml = isHtml;
            MailMessage.Subject = subject;
            MailMessage.Body = message;
        }

        public async Task SendMailAsync()
        {
            SmtpClient.Timeout = 10000;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = false;
            await SmtpClient.SendMailAsync(MailMessage).ConfigureAwait(false);
            SmtpClient.Dispose();
        }

        public async Task SendMailAsync(string username, string password)
        {
            SmtpClient.Credentials = new NetworkCredential(username, password);
            await SendMailAsync().ConfigureAwait(false);
        }
    }
}
