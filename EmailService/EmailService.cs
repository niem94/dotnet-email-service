using System.Threading.Tasks;

namespace EmailService
{
    public abstract class EmailService<TEmailSettings> : IEmailService where TEmailSettings : EmailSettings
    {
        public TEmailSettings Settings { get; set; }
        protected EmailService(TEmailSettings settings)
        {
            Settings = settings;
        }

        public abstract Task SendEmailAsync(string email, string subject, string message, bool isHtml);
    }
}