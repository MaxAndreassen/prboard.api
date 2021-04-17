using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Email.Contracts;
using prboard.api.domain.Email.Contracts.Services;
using prboard.api.domain.Email.Models;
using prboard.api.domain.Exceptions;

namespace prboard.api.domain.Email.Services
{
    [DomainService]
    public class PayoutRequestEmailer : IPayoutRequestEmailer
    {
        private readonly IEmailSender _emailSender;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly LinkConfig _linkConfig;

        public PayoutRequestEmailer(
            IEmailSender emailSender,
            IOptions<LinkConfig> linkConfigOptions,
            IRepository<UserEntity> userRepository
        )
        {
            _emailSender = emailSender;
            _userRepository = userRepository;
            _linkConfig = linkConfigOptions.Value;
        }

        public async Task SendPayoutRequestedEmailAsync(
            string accountId,
            string payoutAmount,
            string payoutId
        )
        {
            var user = await _userRepository
                .FirstOrDefaultAsync(p => p.StripeAccountId == accountId);

            if (user == null)
                throw new HttpResponseException(404);

            await _emailSender.SendEmailAsync(
                "payouts@ecompete.io",
                user.Email,
                "d-1c95a99e1c2b41798210dc6d678b8f11",
                new PayoutCreatedEmail
                {
                    Name = user.UserType.Type == UserType.Individual
                        ? user.FirstName
                        : user.CompanyName,
                    PayoutAmount = payoutAmount,
                    PayoutId = payoutId,
                    PayoutLink = $"{_linkConfig.PlatformBaseUrl}stats/financials/payout/",
                });
        }
    }
}