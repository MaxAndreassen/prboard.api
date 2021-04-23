using System.Net;
using System.Threading;
using System.Threading.Tasks;
using foundation.Configuration;
using Hangfire;
using Microsoft.Extensions.Options;
using prboard.api.domain.Email.Contracts;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace prboard.api.infrastructure.sendgrid.Services
{
    [DomainService]
    public class SendGridEmailSender : IEmailSender
    {
        private readonly SendGridClient _client;

        public SendGridEmailSender(IOptions<SendGridConfig> sendGridOptions)
        {
            _client = new SendGridClient(sendGridOptions.Value.ApiKey);
        }

        public void SendEmailInBackground<T>(
            string sender,
            string recipient,
            string templateId,
            T data
        )
        {
            BackgroundJob.Enqueue<SendGridEmailSender>(service => service
                .SendEmailAsync(sender, recipient, templateId, data));
        }
        
        public async Task<HttpStatusCode> SendEmailAsync<T>(
            string sender,
            string recipient,
            string templateId,
            T data
        )
        {
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(sender, "prboard.io");
            sendGridMessage.AddTo(recipient);
            sendGridMessage.SetTemplateId(templateId);
            sendGridMessage.SetTemplateData(data);

            var response = await _client.SendEmailAsync(sendGridMessage, CancellationToken.None);

            return response.StatusCode;
        }
    }
}