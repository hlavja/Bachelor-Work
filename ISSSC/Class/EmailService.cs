using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISSSC.Class;
using ISSSC.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace ISSSC.Controllers
{
    public interface IEmailService
    {
        Task Send(EmailMessage emailMessage);
    }
    /// <summary>
    /// Class for email service
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public SscisContext Db { get; set; }

        public EmailService(SscisContext context, IEmailConfiguration emailConfiguration)
        {
            Db = context;
            _emailConfiguration = emailConfiguration;
        }

        /// <summary>
        /// Async task for sending emails from application
        /// </summary>
        /// <param name="emailMessage">email message object with preffiled data</param>
        /// <returns></returns>
        public async Task Send(EmailMessage emailMessage)
        {
            EmailAddress emailFrom = new EmailAddress();
            emailFrom.Address = "studentsuportcentre@kiv.zcu.cz";
            emailFrom.Name = "Student Suport Centre";
            List<EmailAddress> listFrom = new List<EmailAddress>();
            listFrom.Add(emailFrom);
            emailMessage.FromAddresses = listFrom;

            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;

            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = emailMessage.Content
            };

            using (var emailClient = new SmtpClient())
            {
                string smtp = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.SMTP, StringComparison.OrdinalIgnoreCase)).Single().ParamValue;
                //no SMTP in database => use default from appsetings.json
                if (string.IsNullOrEmpty(smtp))
                {
                    emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                    emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                }
                else
                {
                    emailClient.Connect(smtp, 465, true);

                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                }


                await emailClient.SendAsync(message).ConfigureAwait(false);

                emailClient.Disconnect(true);
            }
            return;
        }
    }
}
