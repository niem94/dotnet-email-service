using System.Net.Mail;

namespace EmailService.Models
{
    public class EmailMessage
    {
        public EmailMessage(string subject, string body, string fromAdress, string toAddress, bool isHtml)
        {
            Subject = subject;
            Body = body;
            FromAdress = fromAdress;
            ToAddress = toAddress;
            IsHtml = isHtml;
        }
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public string FromAdress { get; set; } = "";
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