using System;
using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Email.Contracts;
using prboard.api.domain.Email.Models;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.domain.Users.Services
{
    [DomainService]
    public class UserVerificationRequestCreateService : IUserVerificationRequestCreateService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<UserVerificationRequestEntity> _userVerificationRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IWorkUnit _workUnit;
        private readonly LinkConfig _linkConfig;

        public UserVerificationRequestCreateService(
            IRepository<UserEntity> userRepository,
            IRepository<UserVerificationRequestEntity> userVerificationRequestRepository,
            IEmailSender emailSender,
            IOptions<LinkConfig> linkOptions,
            IWorkUnit workUnit
            )
        {
            _userRepository = userRepository;
            _userVerificationRequestRepository = userVerificationRequestRepository;
            _emailSender = emailSender;
            _workUnit = workUnit;
            _linkConfig = linkOptions.Value;
        }
        
        public async Task CreateUserVerificationRequestAsync(Guid userUuid)
        {
            var user = await _userRepository.FirstOrDefaultAsync(p => p.Uuid == userUuid);

            var entity = _userVerificationRequestRepository.Create();

            entity.User = user;

            _emailSender.SendEmailInBackground(
                "verify@ecompete.io",
                user.Email,
                "d-9333e74f0fc84cb1aaed48a25ef572b6",
                new VerificationEmail
                {
                    VerifyLink = $"{_linkConfig.VerificationBaseUrl}/{entity.Uuid}",
                    Name = user.FirstName
                }
            );

            await _workUnit.CommitAsync();
        }
    }
}