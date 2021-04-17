using System.Threading.Tasks;
using foundation.Entities.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.Security.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<UserTokenEntity> _userTokenRepository;

        public SecurityService(
            IHttpContextAccessor httpContextAccessor,
            IRepository<UserEntity> userRepository,
            IRepository<UserTokenEntity> userTokenRepository
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
        }

        public async Task<UserEntity> GetCurrentUserAsync()
        {
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("token", out var uuidSalt);

            if (string.IsNullOrEmpty(uuidSalt))
                return null;

            var values = uuidSalt.ToString().Split('_');

            if (values.Length != 2)
                return null;

            if (values[1].Length != 29)
                return null;

            var token = BCrypt.Net.BCrypt.HashPassword(values[0], values[1]);

            var userToken = await _userTokenRepository
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Token == token);

            if (userToken == null)
                return null;
            
            return await _userRepository
                .Include(p => p.UserType)
                .Include(p => p.Country)
                .FirstOrDefaultAsync(p => p.Id == userToken.User.Id);
        }
    }
}