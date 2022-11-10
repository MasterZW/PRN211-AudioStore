
using AudioStore.Utils.Mails;

namespace AudioStore.Helpers.BuilderPattern
{
    public interface IMailBuilder
    {
        MailBuilder AddUser(string smtpUser);
        MailBuilder AddPassword(string smtpPwd);
        MailBuilder AddHost(string smtpHost);
        MailBuilder AddPort(int smtpPort);
        MailBuilder AddToEmail(string toEmail);
        MailBuilder AddSubject(string subject);
        MailBuilder AddBody(string body);
        MailBuilder AddDisplayName(string displayName);

        MailUtils Build();
    }
}