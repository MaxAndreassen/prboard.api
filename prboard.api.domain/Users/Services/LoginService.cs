using System;
using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Requests;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.domain.Users.Services
{
    [DomainService]
    public class LoginService : ILoginService
    {
        private readonly IRepository<UserTokenEntity> _userTokenRepository;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IWorkUnit _workUnit;

        public LoginService(
            IRepository<UserTokenEntity> userTokenRepository,
            IRepository<UserEntity> userRepository,
            IWorkUnit workUnit
            )
        {
            _userTokenRepository = userTokenRepository;
            _userRepository = userRepository;
            _workUnit = workUnit;
        }

        public async Task<string> GenerateTokenAsync(int userId)
        {
            var user = await _userRepository.FirstOrDefaultAsync(p => p.Id == userId);
            
            if (user == null)
                return null;
            
            var entity = _userTokenRepository.Create();

            var uuid = Guid.NewGuid();
            
            entity.User = user;

            var salt = BCrypt.Net.BCrypt.GenerateSalt(BCryptSettings.BCryptWorkFactor);
            
            entity.Token = BCrypt.Net.BCrypt.HashPassword(uuid.ToString(), salt);
            entity.ExpiresAt = DateTime.Now.AddMinutes(180);

            await _workUnit.CommitAsync();

            return $"{uuid}_{salt}";
        }

        public async Task<UserEntity> GetUserAsync(LoginRequest request)
        {
            var user = await _userRepository.FirstOrDefaultAsync(p => p.Email == request.Email);

            var correct = user?.PasswordIsCorrect(request.Password);

            return correct == true ? user : null;
        }
    }
}