using System.Threading.Tasks;
using EmailService.Models;
using Microsoft.Extensions.Options;

namespace EmailService
{
    public abstract class EmailService<TEmailSettings> : IEmailService where TEmailSettings : ProviderSettings, new()
    {
        public TEmailSettings Settings { get; set; }
        protected EmailService(IOptions<TEmailSettings> options)
        {
            Settings = options.Value;
        }

        public abstract Task SendEmailAsync(EmailMessage message);
    }
}