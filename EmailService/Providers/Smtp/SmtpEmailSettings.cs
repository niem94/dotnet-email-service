namespace EmailService.Providers.Smtp
{
    public class SmtpEmailSettings : EmailSettings
    {
        public int Port { get; set; } = 0;
        public string Password { get; set; }
    }
}