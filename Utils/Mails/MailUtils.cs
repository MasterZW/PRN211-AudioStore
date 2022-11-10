using System.Net;
using System.Net.Mail;
using System.Text;

namespace AudioStore.Utils.Mails
{
    public class MailUtils
    {
        public string SmtpUser { get; set; }
        public string SmtpPwd { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string DisplayName { get; set; }

        public MailUtils(string smtpUserName, string smtpPwd, string smtpHost, int smtpPort, string toEmail, string subject, string body, string displayName)
        {
            this.SmtpUser = smtpUserName;
            this.SmtpPwd = smtpPwd;
            this.SmtpHost = smtpHost;
            this.SmtpPort = smtpPort;
            this.ToEmail = toEmail;
            this.Subject = subject;
            this.Body = body;
            this.DisplayName = displayName;
        }
        public bool Send()
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Host = SmtpHost; //smtp.gmail.com
                    smtpClient.Port = SmtpPort; //587 || 25
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(SmtpUser, SmtpPwd);

                    var msg = new MailMessage()
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(SmtpUser, DisplayName),
                        Subject = Subject,
                        Body = Body,
                        Priority = MailPriority.Normal
                    };
                    msg.To.Add(ToEmail);
                    smtpClient.Send(msg);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}