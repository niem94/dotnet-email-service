using System;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;

namespace EmailService
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEmailService(this IServiceCollection services,
            Action<MailSettings> mailSection)
        {
            services.Configure(mailSection);
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}