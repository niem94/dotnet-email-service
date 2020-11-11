using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace EmailService
{
    public abstract class EmailService<TOptions> where TOptions : ProviderOptions
    {
        public ProviderOptions Options { get; set; }
        protected EmailService(IOptions<TOptions> options)
        {
            Options = options.Value;
        }

        public abstract Task SendEmailAsync(EmailMessage message);
    }
}