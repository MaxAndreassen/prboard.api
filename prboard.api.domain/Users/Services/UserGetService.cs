using System;
using System.Threading.Tasks;
using AutoMapper;
using foundation.Configuration;
using foundation.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Models;
using prboard.api.domain.Users.Services.Contracts;

namespace prboard.api.domain.Users.Services
{
    [DomainService]
    public class UserGetService : IUserGetService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UserGetService(
            IRepository<UserEntity> userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<T> GetAsync<T>(Guid uuid) where T : UserSummaryAnon
        {
            var entity = await _userRepository.FirstOrDefaultAsync(p => p.Uuid == uuid);

            return _mapper.Map<T>(entity);
        }
    }
}