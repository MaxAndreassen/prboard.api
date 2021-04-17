using System.Net;
using System.Threading.Tasks;

namespace prboard.api.domain.Email.Contracts
{
    public interface IEmailSender
    {
        void SendEmailInBackground<T>(
            string sender,
            string recipient,
            string templateId,
            T data
        );

        Task<HttpStatusCode> SendEmailAsync<T>(
            string sender,
            string recipient,
            string templateId,
            T data
        );
    }
}