using CK.Central.Core.Abstract.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using CK.Central.Core.DataObjects.Model;

namespace CK.Central.Core.Services
{
    public class EmailSendBaseService : IEmailSendBaseService
    {
        private readonly SmtpSettingsModel _smtpSettings;

        public EmailSendBaseService(IConfiguration configuration)
        {
            _smtpSettings = configuration.GetSection("Email").Get<SmtpSettingsModel>();
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string message)
        {
            var email = new MailMessage
            {
                From = new MailAddress(_smtpSettings.FromEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = false // Set to true if the message contains HTML
            };
            email.To.Add(new MailAddress(toEmail));

            //email.From.Add(MailboxAddress.Parse(_smtpSettings.FromEmail));
            //email.To.Add(MailboxAddress.Parse(_smtpSettings.FromEmail));
            //email.Subject=subject;
            //email.Body=new TextPart(TextFormat.Plain) { Text=message};

            using (var smtp = new SmtpClient())
            {
                smtp.Port = (int)_smtpSettings.Port;
                smtp.EnableSsl = true;
                smtp.Host = _smtpSettings.Server;
                smtp.Credentials = new NetworkCredential(userName: _smtpSettings.Username, password: _smtpSettings.Password);
                await smtp.SendMailAsync(email)
    ;
                return true;
            }
        }
    }
}