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
    public class UserPasswordResetRequestCreateService : IUserPasswordResetRequestCreateService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<UserPasswordResetRequestEntity> _userPasswordResetRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IWorkUnit _workUnit;
        private readonly LinkConfig _linkConfig;

        public UserPasswordResetRequestCreateService(
            IRepository<UserEntity> userRepository,
            IRepository<UserPasswordResetRequestEntity> userPasswordResetRequestRepository,
            IEmailSender emailSender,
            IOptions<LinkConfig> linkConfigOptions,
            IWorkUnit workUnit
        )
        {
            _userRepository = userRepository;
            _userPasswordResetRequestRepository = userPasswordResetRequestRepository;
            _emailSender = emailSender;
            _workUnit = workUnit;
            _linkConfig = linkConfigOptions.Value;
        }

        public async Task CreateAsync(string email)
        {
            var user = await _userRepository
                .FirstOrDefaultAsync(p => p.Email == email && p.DeletedAt == null);

            if (user == null)
                return;

            var entity = _userPasswordResetRequestRepository.Create();

            entity.User = user;

            await _workUnit.CommitAsync();

            _emailSender.SendEmailInBackground(
                "reset@ecompete.io", 
                email, 
                "d-cbf12e3c84154f2ebb8485b905536f6c",
                new PasswordResetEmail
                {
                    Name = user.Name,
                    Link = $"{_linkConfig.PasswordResetBaseUrl}/{entity.Uuid}",
                });
        }
    }
}