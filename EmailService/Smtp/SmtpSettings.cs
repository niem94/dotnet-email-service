namespace EmailService.Smtp
{
    public class SmtpSettings : ProviderSettings
    {
        public string Host { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public int Port { get; set; } = 443;
        public string Email { get; set; } = "";
        public bool EnableSsl { get; set; } = true;
        public bool UseDefaultCredentials { get; set; } = true;
        public string DisplayName { get; set; } = "";
    }
}