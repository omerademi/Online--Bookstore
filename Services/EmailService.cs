using BookStore.Data.Entities;
using BookStore.Services.Service.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void SendMail(Email email)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(email.To));
            message.From.Add(new MailboxAddress(_emailConfiguration.AppEmailFrom));
            message.Subject = email.Subject;
            message.Body = new TextPart()
            {
                Text = email.Text
            };

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, SecureSocketOptions.StartTls);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }
        }
    }
}
