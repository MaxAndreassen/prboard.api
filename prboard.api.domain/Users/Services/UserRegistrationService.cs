using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using foundation.Helpers;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Countries.Entities;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Enums;
using prboard.api.domain.Users.Requests;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.domain.Users.Services
{
    [DomainService]
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<CountryEntity> _countryRepository;
        private readonly IRepository<UserTypeEntity> _userTypeRepository;
        private readonly IWorkUnit _workUnit;
        private readonly ISecurityService _securityService;
        private readonly IUserVerificationRequestCreateService _userVerificationRequestCreateService;

        public UserRegistrationService(
            IRepository<UserEntity> userRepository,
            IRepository<CountryEntity> countryRepository,
            IRepository<UserTypeEntity> userTypeRepository,
            IWorkUnit workUnit,
            ISecurityService securityService,
            IUserVerificationRequestCreateService userVerificationRequestCreateService
        )
        {
            _userRepository = userRepository;
            _countryRepository = countryRepository;
            _userTypeRepository = userTypeRepository;
            _workUnit = workUnit;
            _securityService = securityService;
            _userVerificationRequestCreateService = userVerificationRequestCreateService;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existing = await _userRepository
                .FirstOrDefaultAsync(p => p.Email == request.Email || p.Username == request.Username);

            if (existing != null)
                return null;

            var entity = _userRepository.Create();
            entity.Email = request.Email;
            entity.Username = request.Username ?? $"Guest_{PasswordGenerator.GeneratePassword(8)}";

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.CompanyName = request.CompanyName;

            entity.Country = await _countryRepository.FirstOrDefaultAsync(p => p.Uuid == request.CountryUuid);
            entity.UserType = request.IsBusiness
                ? await _userTypeRepository.FirstOrDefaultAsync(p => p.Type == UserType.Business)
                : await _userTypeRepository.FirstOrDefaultAsync(p => p.Type == UserType.Individual);
            entity.OptedIntoMarketingEmails = request.OptedIntoMarketingEmails;
            
            var temporaryPassword = PasswordGenerator.GeneratePassword(10);

            if (request.IsSilent)
                request.Password = temporaryPassword;

            if (!string.IsNullOrEmpty(request.Password))
                entity.ChangePassword(request.Password);

            await _workUnit.CommitAsync();

            if (!request.IsSilent)
                await _userVerificationRequestCreateService.CreateUserVerificationRequestAsync(entity.Uuid);

            return new RegistrationResponse
            {
                Password = request.Password
            };
        }

        public async Task<string> TestAsync()
        {
            return (await _securityService.GetCurrentUserAsync()).Username;
        }
    }
}