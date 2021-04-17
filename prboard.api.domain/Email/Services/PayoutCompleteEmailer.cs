using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Email.Contracts;
using prboard.api.domain.Email.Contracts.Services;
using prboard.api.domain.Email.Models;
using prboard.api.domain.Exceptions;

namespace prboard.api.domain.Email.Services
{
    [DomainService]
    public class PayoutCompleteEmailer : IPayoutCompleteEmailer
    {
        private readonly IEmailSender _emailSender;
        private readonly IRepository<UserEntity> _userRepository;

        public PayoutCompleteEmailer(
            IEmailSender emailSender,
            IRepository<UserEntity> userRepository
        )
        {
            _emailSender = emailSender;
            _userRepository = userRepository;
        }
        
        public async Task SendPayoutCompleteEmailAsync(
            string accountId,
            string payoutAmount,
            string payoutId
        )
        {
            var user = await _userRepository
                .FirstOrDefaultAsync(p => p.StripeAccountId == accountId);

            if (user == null)
                throw new HttpResponseException(404);

            _emailSender.SendEmailInBackground(
                "payouts@ecompete.io",
                user.Email,
                "d-30ff73fe4cc34a4c94e0e69bd460919c",
                new PayoutCompleteEmail
                {
                    Name = user.UserType.Type == UserType.Individual
                        ? user.FirstName
                        : user.CompanyName,
                    PayoutAmount = payoutAmount,
                    PayoutId = payoutId
                });
        }
    }
}