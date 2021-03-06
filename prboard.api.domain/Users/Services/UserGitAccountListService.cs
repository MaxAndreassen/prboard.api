using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UserGitAccountListService : IUserGitAccountListService
    {
        private readonly IRepository<UserGitAccountEntity> _userGitAccountRepository;
        private readonly IMapper _mapper;

        public UserGitAccountListService(
            IRepository<UserGitAccountEntity> userGitAccountRepository,
            IMapper mapper
        )
        {
            _userGitAccountRepository = userGitAccountRepository;
            _mapper = mapper;
        }

        public async Task<IList<T>> ListUserGitAccountsAsync<T>(UserGitAccountQueryParams request) where T : class
        {
            var query = _userGitAccountRepository.Where(p => p.DeletedAt == null);

            if (request.UserUuid != null)
            {
                query = query
                    .Include(p => p.User)
                    .Where(p => p.User.Uuid == request.UserUuid);
            }
            
            if (!string.IsNullOrEmpty(request.SourceIdentifier))
            {
                query = query
                    .Include(p => p.User)
                    .Where(p => p.SourceUserIdentifier == request.SourceIdentifier);
            }
                
            return await _mapper.ProjectTo<T>(query).ToListAsync();
        }
    }
}