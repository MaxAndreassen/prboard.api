using System.Threading.Tasks;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.SubscriptionEvents.Entities;
using prboard.api.data.Users.Entities;
using prboard.api.domain.SubscriptionEvents.Contracts.Services;
using prboard.api.domain.SubscriptionEvents.Models;

namespace prboard.api.domain.SubscriptionEvents.Services
{
    [DomainService]
    public class SubscriptionEventCreateService : ISubscriptionEventCreateService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<SubscriptionEventEntity> _subscriptionRepository;
        private readonly IWorkUnit _workUnit;

        public SubscriptionEventCreateService(
            IRepository<UserEntity> userRepository,
            IRepository<SubscriptionEventEntity> subscriptionRepository,
            IWorkUnit workUnit
            )
        {
            _userRepository = userRepository;
            _subscriptionRepository = subscriptionRepository;
            _workUnit = workUnit;
        }
        
        public async Task CreateSubscriptionAsync(SubscriptionEventEditor eventEditor)
        {
            var entity = eventEditor.Uuid == null
                ? _subscriptionRepository.Create()
                : await _subscriptionRepository.FirstOrDefaultAsync(p => p.Uuid == eventEditor.Uuid);

            entity.Plan = eventEditor.Plan;
            entity.ValidUntil = eventEditor.ValidUntil;
            entity.User = await _userRepository.FirstOrDefaultAsync(p => p.Uuid == eventEditor.UserUuid);
            entity.Failure = true;

            await _workUnit.CommitAsync();
        }
    }
}