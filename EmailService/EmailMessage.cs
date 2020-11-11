using System.Net.Mail;

namespace EmailService
{
    public class EmailMessage
    {
        public EmailMessage(string subject, string body, string fromAddress, string toAddress, bool isHtml)
        {
            Subject = subject;
            Body = body;
            FromAddress = fromAddress;
            ToAddress = toAddress;
            IsHtml = isHtml;
        }
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string FromName { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string ToName { get; set; } = "";
        public string ReplyToAddress { get; set; } = "";
        public string ReplyToName { get; set; } = "";
        public string Bcc { get; set; } = "";
        public string Cc { get; set; } = "";
        public bool IsHtml { get; set; } = true;
        public MailPriority MailPriority { get; set; }
    }
}