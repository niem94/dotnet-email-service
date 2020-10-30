using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace EmailService
{
    public abstract class EmailService<TEmailSettings> : IEmailService where TEmailSettings : EmailSettings, new()
    {
        public TEmailSettings Settings { get; set; }
        protected EmailService(IOptions<TEmailSettings> options)
        {
            Settings = options.Value;
        }

        public abstract Task SendEmailAsync(string email, string subject, string message, bool isHtml);
    }
}