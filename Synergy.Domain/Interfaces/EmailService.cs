using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Synergy.Domain.Constants;
using Synergy.Domain.ServiceModel;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Synergy.Domain.Interfaces
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailConfigurationProvider> _emailConfigurationProvider;

        public EmailService(IOptions<EmailConfigurationProvider> emailConfigurationProvider)
        {
            _emailConfigurationProvider = emailConfigurationProvider;
        }

        private void OldSendEmail(EmailRequest request)
        {
            try
            {
                MailMessage mail = new MailMessage();
                var ConfigReader = _emailConfigurationProvider.Value;
                mail.To.Add(request.To);
                if (!string.IsNullOrEmpty(ConfigReader.CopyAddresses))
                    mail.CC.Add(ConfigReader.CopyAddresses);

                mail.From = new MailAddress(ConfigReader.FromEmail, ConfigReader.SenderName);
                mail.Subject = request.Subject;
                mail.IsBodyHtml = true;
                mail.Body = request.Body;

                using (SmtpClient SmtpServer = new SmtpClient(ConfigReader.SmtpHost))
                {
                    Object state = mail;

                    SmtpServer.Port = Convert.ToInt16(ConfigReader.SmtpPort);
                    SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigReader.SmtpUser, ConfigReader.SmtpPassword);
                    SmtpServer.EnableSsl = Convert.ToBoolean(ConfigReader.SmtpEnableSSL);
                    SmtpServer.Send(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendEmail(EmailRequest request)
        {
            try
            {
                var ConfigReader = _emailConfigurationProvider.Value;
                var client = new SendGridClient(ConfigReader.ApiKey.Trim());
                var from = new EmailAddress(ConfigReader.FromEmail.Trim(), ConfigReader.SenderName);
                var subject = request.Subject;

                List<EmailAddress> to = new List<EmailAddress>
                {
                    new EmailAddress(request.To.Trim())
                };

                if (!string.IsNullOrEmpty(ConfigReader.CopyAddresses.Trim()))
                {
                    var addresses = Utilities.GetCopyEmailAddresses(ConfigReader.CopyAddresses);
                    if (addresses.Count > 0)
                    {
                        to.AddRange(addresses);
                    }
                }
                var htmlContent = request.Body;
                var message = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", htmlContent);
                client.SendEmailAsync(message);
            }
            catch
            {

            }

        }
    }
}
