using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using EmailService.Providers.SendGrid;
using EmailService.Providers.Smtp;

namespace EmailService
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEmailService(this IServiceCollection services,
            Action<EmailSettings> options)
        {
            services.Configure(options);
            services.AddTransient<IEmailService, SmtpEmailService>();
        }

        public static void AddSendGridEmailService(this IServiceCollection services,
           Action<SendGridEmailSettings> options)
        {
            services.Configure(options);
            services.AddTransient<IEmailService, SendGridEmailService>();
        }
    }
}