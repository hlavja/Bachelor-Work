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

    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public SscisContext Db { get; set; }

        public EmailService(SscisContext context, IEmailConfiguration emailConfiguration)
        {
            Db = context;
            _emailConfiguration = emailConfiguration;
        }

        public async Task Send(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = emailMessage.Content
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                string smtp = Db.SscisParam.Where(p => p.ParamKey.Equals(SSCISParameters.SMTP, StringComparison.OrdinalIgnoreCase)).Single().ParamValue;
                if (string.IsNullOrEmpty(smtp))
                {
                    //The last parameter here is to use SSL (Which you should!)
                    emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);

                    //Remove any OAuth functionality as we won't be using it. 
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                    emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                }
                else
                {
                    //The last parameter here is to use SSL (Which you should!)
                    emailClient.Connect(smtp, 465, true);

                    //Remove any OAuth functionality as we won't be using it. 
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                }


                await emailClient.SendAsync(message);

                emailClient.Disconnect(true);
            }
            return;
        }
    }
}
