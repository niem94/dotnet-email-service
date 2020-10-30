using System.Net.Mail;

namespace EmailService.Models
{
    public class EmailMessage
    {
        public string Subject { get; set; } = "Default Email Subject";
        public string Body { get; set; } = "Defualt Email body";
        public string FromAdress { get; set; } = "email-service@dotnet.com";
        public string FromName { get; set; } = "Default Name";
        public string ToAddress { get; set; } = "Default Name";
        public string ToName { get; set; } = "Default Name";
        public string ReplyToAddress { get; set; } = "";
        public string ReplyToName { get; set; } = "";
        public string Bcc { get; set; } = "";
        public string Cc { get; set; } = "";
        public bool IsHtml { get; set; } = true;
        public MailPriority MailPriority { get; set; }
    }
}