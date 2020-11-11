using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using EmailService.Smtp;
using EmailService.SendGrid;

namespace EmailService
{
    public static class ServiceCollectionExtensions
    {
        public static IConfiguration Configuration { get; set; }
        public static void AddEmailService(this IServiceCollection services)
        {
            SmtpSettings settings = Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
            services.AddSmtpEmailService(options => options = settings);
        }

        public static void AddEmailService(this IServiceCollection services,
            Action<SmtpSettings> options)
        {
            services.AddSmtpEmailService(options);
        }

        public static void AddEmailService(this IServiceCollection services,
            SmtpSettings options)
        {
            services.AddSmtpEmailService(options);
        }

        //TODO: Extract to dotnet-email-service.Smtp
        public static void AddSmtpEmailService(this IServiceCollection services,
                   Action<SmtpSettings> options)
        {
            services.Configure(options);
            services.AddTransient<IEmailService, SmtpEmailService>();
        }

        public static void AddSmtpEmailService(this IServiceCollection services,
                   SmtpSettings options)
        {
            services.ConfigureOptions(options);
            services.AddTransient<IEmailService, SmtpEmailService>();
        }

        //TODO: Extract to dotnet-email-service.SendGrid
        public static void AddSendGridEmailService(this IServiceCollection services,
           Action<SendGridSettings> options)
        {
            services.Configure(options);
            services.AddTransient<IEmailService, SendGridEmailService>();
        }

        public static void AddSendGridEmailService(this IServiceCollection services,
           SendGridSettings options)
        {
            services.ConfigureOptions(options);
            services.AddTransient<IEmailService, SendGridEmailService>();
        }
    }
}