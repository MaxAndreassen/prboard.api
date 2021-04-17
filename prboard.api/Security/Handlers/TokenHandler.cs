using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using foundation.Entities.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.Security.Handlers
{
    public class TokenHandler : AuthenticationHandler<TokenOptions>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<UserTokenEntity> _userTokenRepository;
        private readonly IWorkUnit _workUnit;
        private readonly ISecurityService _securityService;

        public TokenHandler(
            IOptionsMonitor<TokenOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IHttpContextAccessor httpContextAccessor,
            IRepository<UserTokenEntity> userTokenRepository,
            IWorkUnit workUnit,
            ISecurityService securityService
        ) : base(options, logger, encoder, clock)
        {
            _httpContextAccessor = httpContextAccessor;
            _userTokenRepository = userTokenRepository;
            _workUnit = workUnit;
            _securityService = securityService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("token", out var token);

            if (string.IsNullOrEmpty(token))
                return AuthenticateResult.Fail($"Invalid Token.");

            var values = token.ToString().Split('_');

            if (values.Length != 2)
                return null;

            var user = await _securityService.GetCurrentUserAsync();

            if (user == null)
                return AuthenticateResult.Fail($"Invalid Token.");
            
            user.LastActive = DateTime.Now;

            var userToken = await _userTokenRepository
                .Include(p => p.User)
                .OrderByDescending(p => p.ExpiresAt)
                .FirstOrDefaultAsync(p => p.User.Uuid == user.Uuid);

            if (userToken == null)
                return AuthenticateResult.Fail($"Invalid Token.");

            if (userToken.ExpiresAt < DateTime.Now)
                return AuthenticateResult.Fail($"Expired Token.");

            userToken.ExpiresAt = DateTime.Now.AddMinutes(180);

            await _workUnit.CommitAsync();

            var claims = new[] {new Claim("token", values[0])};
            var identity = new ClaimsIdentity(claims, nameof(TokenHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}