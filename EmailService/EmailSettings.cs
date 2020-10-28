namespace EmailService
{
    public class EmailSettings
    {
        public string Type { get; set; }
        public string Host { get; set; }
        public int Port { get; set; } = 0;
        public string Username { get; set; }
        public string Password { get; set; }
    }
}