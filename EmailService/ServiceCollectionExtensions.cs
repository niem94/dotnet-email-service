using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace EmailService
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEmailService(this IServiceCollection services,
            IConfigurationSection mailSettings)
        {
            services.Configure<EmailSettings>(mailSettings);
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}