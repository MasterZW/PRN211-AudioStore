using System;
using AudioStore.Utils.Mails;

namespace AudioStore.Helpers.BuilderPattern
{
    public class MailBuilder : IMailBuilder
    {
        public string SmtpUser { get; set; }
        public string SmtpPwd { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string DisplayName { get; set; }

        public MailBuilder AddBody(string body)
        {
            Body = body;
            return this;
        }

        public MailBuilder AddDisplayName(string displayName)
        {
            DisplayName = displayName;
            return this;
        }

        public MailBuilder AddHost(string smtpHost)
        {
            SmtpHost = smtpHost;
            return this;
        }

        public MailBuilder AddPassword(string smtpPwd)
        {
            SmtpPwd = smtpPwd;
            return this;
        }

        public MailBuilder AddPort(int smtpPort)
        {
            SmtpPort = smtpPort;
            return this;
        }

        public MailBuilder AddSubject(string subject)
        {
            Subject = subject;
            return this;
        }

        public MailBuilder AddToEmail(string toEmail)
        {
            ToEmail = toEmail;
            return this;
        }

        public MailBuilder AddUser(string smtpUser)
        {
            SmtpUser = smtpUser;
            return this;
        }

        public MailUtils Build()
        {
            return new MailUtils(SmtpUser, SmtpPwd, SmtpHost, SmtpPort, ToEmail, Subject, Body, DisplayName);
        }
    }
}