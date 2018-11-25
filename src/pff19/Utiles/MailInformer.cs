using System;
using Microsoft.Extensions.Configuration;
using pff19.DataAccess.Models;
using pff19.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Logging;

namespace pff19.Utiles
{

    public class MailInformer : IInformer
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public MailInformer(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public void InformAboutContactRequest(ContactRequest contactRequest, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine("Hallo")
                .AppendLine()
                .AppendLine($"Auf pff19.ch ist eine neue Kontaktanfrage eingegangen von: {contactRequest.FirstName} {contactRequest.LastName} ({contactRequest.Mail})")
                .AppendLine($"Link zur Anfrage: {url}")
                .AppendLine()
                .AppendLine("********************************************************************")
                .AppendLine()
                .AppendLine(contactRequest.Text)
                .AppendLine()
                .AppendLine("********************************************************************")
                .AppendLine()
                .AppendLine("Dieses Email wurde automatisch generiert, bitte antworte nicht darauf.");
            SendMail(_configuration["Mail:ContactRequestReceiver"], "Pff19: Neue Kontaktanfrage", sb.ToString());
        }

        private void SendMail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage(_configuration["Mail:From"], to)
            {
                Subject = subject,
                Body = body
            };
            SmtpClient client = new SmtpClient
            {
                Port = _configuration.GetValue<int>("Mail:Port"),
                EnableSsl = true,
                Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = _configuration["Mail:Host"]
            };
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"Failed to send email to '{to}' with subject '{subject}'.");
            }
        }
    }
}
