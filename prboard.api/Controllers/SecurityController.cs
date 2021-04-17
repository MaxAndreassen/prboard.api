using System;
using System.Threading.Tasks;
using AutoMapper;
using foundation.Entities.Contracts;
using foundation.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Email.Models;
using prboard.api.domain.Exceptions;
using prboard.api.domain.Users.Models;
using prboard.api.domain.Users.Requests;
using prboard.api.domain.Users.Services.Contracts;
using prboard.api.Security;

namespace prboard.api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly ILoginService _loginService;
        private readonly IUserEditService _userEditService;
        private readonly IUserGetService _userGetService;
        private readonly ISecurityService _securityService;
        private readonly IUserVerificationService _userVerificationService;
        private readonly IUserVerificationRequestCreateService _userVerificationRequestCreateService;
        private readonly IUserPasswordResetRequestCreateService _userPasswordResetRequestCreateService;
        private readonly IDomainValidator<RegistrationRequest> _registrationRequestValidator;
        private readonly IDomainValidator<UserEditor> _userEditorValidator;
        private readonly IDomainValidator<PasswordResetRequest> _passwordRequestValidator;
        private readonly IDomainValidator<EmailRequest> _emailRequestValidator;
        private readonly IMapper _mapper;
        private readonly IRepository<UserPasswordResetRequestEntity> _userPasswordResetRequestRepository;
        private readonly IWorkUnit _workUnit;

        public SecurityController(
            IUserRegistrationService userRegistrationService,
            ILoginService loginService,
            IUserEditService userEditService,
            IUserGetService userGetService,
            ISecurityService securityService,
            IUserVerificationService userVerificationService,
            IUserVerificationRequestCreateService userVerificationRequestCreateService,
            IUserPasswordResetRequestCreateService userPasswordResetRequestCreateService,
            IDomainValidator<RegistrationRequest> registrationRequestValidator,
            IDomainValidator<UserEditor> userEditorValidator,
            IDomainValidator<PasswordResetRequest> passwordRequestValidator,
            IDomainValidator<EmailRequest> emailRequestValidator,
            IMapper mapper,
            IRepository<UserPasswordResetRequestEntity> userPasswordResetRequestRepository,
            IWorkUnit workUnit
        )
        {
            _userRegistrationService = userRegistrationService;
            _loginService = loginService;
            _userEditService = userEditService;
            _userGetService = userGetService;
            _securityService = securityService;
            _userVerificationService = userVerificationService;
            _userVerificationRequestCreateService = userVerificationRequestCreateService;
            _userPasswordResetRequestCreateService = userPasswordResetRequestCreateService;
            _registrationRequestValidator = registrationRequestValidator;
            _userEditorValidator = userEditorValidator;
            _passwordRequestValidator = passwordRequestValidator;
            _emailRequestValidator = emailRequestValidator;
            _mapper = mapper;
            _userPasswordResetRequestRepository = userPasswordResetRequestRepository;
            _workUnit = workUnit;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        [Route("check")]
        public async Task<IActionResult> SecurityCheck()
        {
            return await Task.FromResult(Ok());
        }

        [HttpGet]
        [Route("verify/{userVerificationRequestUuid}")]
        public async Task<IActionResult> SecurityCheck(Guid userVerificationRequestUuid)
        {
            await _userVerificationService.VerifyAsync(userVerificationRequestUuid);

            return Ok();
        }
        
        [HttpGet]
        [Route("username/{username}")]
        public async Task<IActionResult> GetByUsernameAsync([FromRoute] string username)
        {
            var user = await _userGetService.GetByUsernameAsync<UserSummaryPersonal>(username);

            if (user == null)
                return NotFound();

            var currentUser = await _securityService.GetCurrentUserAsync();

            if (currentUser == null || currentUser.Uuid != user.Uuid)
                return Ok(_mapper.Map<UserSummaryAnon>(user));

            return Ok(user);
        }

        [HttpGet]
        [Route("{uuid}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid uuid)
        {
            var user = await _userGetService.GetAsync<UserSummaryPersonal>(uuid);

            if (user == null)
                return NotFound();

            var currentUser = await _securityService.GetCurrentUserAsync();

            if (currentUser == null || currentUser.Uuid != user.Uuid)
                return Ok(_mapper.Map<UserSummaryAnon>(user));

            return Ok(user);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        [Route("verify/resend")]
        public async Task<IActionResult> ResendVerifyEmailAsync()
        {
            var currentUser = await _securityService.GetCurrentUserAsync();

            if (currentUser.IsEmailVerified)
                throw new HttpResponseException(405);

            await _userVerificationRequestCreateService.CreateUserVerificationRequestAsync(currentUser.Uuid);

            return Ok();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = Schemes.TokenAuthenticationDefaultScheme)]
        [Route("edit")]
        public async Task<IActionResult> UpdateAsync([FromForm] UserEditor editor)
        {
            var validationResult = _userEditorValidator.Validate(editor);

            if (!validationResult.Valid)
                return StatusCode(StatusCodes.Status412PreconditionFailed, validationResult);

            var user = await _userEditService.UpdateAsync<UserEditor>(editor);

            if (user != null)
                return Ok(user);

            return BadRequest();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest request)
        {
            var validationResult = _registrationRequestValidator.Validate(request);

            if (!validationResult.Valid)
                return StatusCode(StatusCodes.Status412PreconditionFailed, validationResult);

            var result = await _userRegistrationService.RegisterAsync(request);

            if (result != null)
                return Ok();

            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var user = await _loginService.GetUserAsync(request);

            if (user == null)
                return BadRequest();

            var loginResponse = new LoginResponse {Email = user.Email, Username = user.Username, Uuid = user.Uuid};

            var token = await _loginService.GenerateTokenAsync(user.Id);

            loginResponse.Token = token;

            return Ok(loginResponse);
        }

        [HttpPost]
        [Route("forgotten-password")]
        public async Task<IActionResult> ForgottenPasswordAsync(EmailRequest request)
        {
            var validationResult = _emailRequestValidator.Validate(request);

            if (!validationResult.Valid)
                return StatusCode(StatusCodes.Status412PreconditionFailed, validationResult);
            
            await _userPasswordResetRequestCreateService.CreateAsync(request.Email);

            return Ok();
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(PasswordResetRequest request)
        {
            var validationResult = _passwordRequestValidator.Validate(request);
            
            if (!validationResult.Valid)
                return StatusCode(StatusCodes.Status412PreconditionFailed, validationResult);
            
            var attemptEntity = await _userPasswordResetRequestRepository
                .Include(p => p.User)
                    .FirstOrDefaultAsync(p => p.Uuid == request.AttemptUuid &&
                                              p.DeletedAt == null
                    );

            if (attemptEntity == null)
                throw new HttpResponseException(404);
            
            if (attemptEntity.CreatedAt < DateTime.Now.AddHours(-1))
                throw new HttpResponseException(400);

            await _userEditService.ChangePasswordAsync(attemptEntity.User, request.Password);
            
            attemptEntity.DeletedAt = DateTime.Now;

            await _workUnit.CommitAsync();

            return Ok(true);
        }
    }
}