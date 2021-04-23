using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.data.Users.Enums;
using prboard.api.domain.PaymentProviders.Contracts;
using prboard.api.domain.Users.Requests;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.domain.Users.Services
{
    [DomainService]
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<UserTypeEntity> _userTypeRepository;
        private readonly IWorkUnit _workUnit;
        private readonly IPaymentProviderCreateCustomerService _paymentProviderCreateCustomerService;

        public UserRegistrationService(
            IRepository<UserEntity> userRepository,
            IRepository<UserTypeEntity> userTypeRepository,
            IWorkUnit workUnit,
            IPaymentProviderCreateCustomerService paymentProviderCreateCustomerService
        )
        {
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _workUnit = workUnit;
            _paymentProviderCreateCustomerService = paymentProviderCreateCustomerService;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existing = await _userRepository
                .FirstOrDefaultAsync(p => p.Email == request.Email);

            if (existing != null)
                return null;

            var entity = _userRepository.Create();
            entity.Email = request.Email;
            entity.Name = request.Name;
            entity.UserType = await _userTypeRepository.FirstOrDefaultAsync(p => p.Type == UserType.Individual);
            entity.OptedIntoMarketingEmails = request.OptedIntoMarketingEmails;

            if (!string.IsNullOrEmpty(request.Password))
                entity.ChangePassword(request.Password);

            var customerId = await _paymentProviderCreateCustomerService.CreateCustomerAsync(entity);

            entity.StripeCustomerId = customerId;
            
            await _workUnit.CommitAsync();

            return new RegistrationResponse
            {
                Password = request.Password
            };
        }
    }
}