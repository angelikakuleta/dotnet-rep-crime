using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using REP_CRIME01.CrimeFeedback.Settings;
using REP_CRIME01.EventBus.Messages;
using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace REP_CRIME01.CrimeFeedback.Services
{
    class MailSender : ISender
    {
        private readonly ILogger<MailSender> _logger;
        private readonly SMTPSettings _settings;

        public MailSender(ILogger<MailSender> logger, IOptions<SMTPSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task Send(CrimeEventAssignedNotification message)
        {
            _logger.LogInformation($"Sending email to {message.ReportingPersonEmail}...");

            StringBuilder template = new();
            template.AppendLine("<h1>Your report has been processed</h1>");
            template.AppendLine($"Cirme event report with id {message.Id} has been assigned to the police officer.");

            try
            {
                using MailMessage mail = new();
                mail.From = new MailAddress(_settings.MailFrom);
                mail.To.Add(message.ReportingPersonEmail);
                mail.Subject = "Crime Feedback";
                mail.Body = template.ToString();
                mail.IsBodyHtml = true;

                using SmtpClient smtp = new(_settings.Host, _settings.Port);
                smtp.Credentials = new System.Net.NetworkCredential(_settings.UserName, _settings.Password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);

                _logger.LogInformation("Email has been send successfully.");
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occurred while sending an email: {e.Message}");
            }
        }
    }
}
