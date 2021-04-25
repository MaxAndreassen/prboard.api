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
    public class UserGitAccountEditService : IUserGitAccountEditService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<UserGitAccountEntity> _userGitAccountRepository;
        private readonly IRepository<GitAccountSourceEntity> _gitAccountSourceRepository;
        private readonly IMapper _mapper;

        public UserGitAccountEditService(
            IRepository<UserEntity> userRepository,
            IRepository<UserGitAccountEntity> userGitAccountRepository,
            IRepository<GitAccountSourceEntity> gitAccountSourceRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _userGitAccountRepository = userGitAccountRepository;
            _gitAccountSourceRepository = gitAccountSourceRepository;
            _mapper = mapper;
        }
        
        public async Task<T> UpdateAsync<T>(UserGitAccountEditor editor) where T : class
        {
            var user = await _userRepository.FirstOrDefaultAsync(p => p.Uuid == editor.UserUuid);

            var gitAccountSource = await _gitAccountSourceRepository
                    .FirstOrDefaultAsync(p => p.Type == editor.AccountType);

            var entity = editor.Uuid == null
                ? _userGitAccountRepository.Create()
                : await _userGitAccountRepository.FirstOrDefaultAsync(p => p.Uuid == editor.Uuid);

            entity.User = user;
            entity.GitAccountSource = gitAccountSource;
            entity.Token = editor.AccessToken;
            entity.SourceUserIdentifier = editor.SourceUserIdentity;

            return _mapper.Map<T>(entity);
        }
    }
}