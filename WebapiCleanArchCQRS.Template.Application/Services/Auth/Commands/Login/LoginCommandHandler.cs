using MediatR;
using WebapiCleanArchCQRS.Template.Domain.Interfaces.AppUsers;
using WebapiCleanArchCQRS.Template.Shared.Helpers.ErrorMessages;
using WebapiCleanArchCQRS.Template.Shared.Results;

namespace WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Login
{
    
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, Result>
    {
        private readonly IAppUserRepository appUserRepository;

        public LoginCommandHandler(IAppUserRepository appUserRepository)
        {
            this.appUserRepository = appUserRepository;
        }

        public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginDTO = request.loginDTO;

            var user = await appUserRepository.FindByEmailAsync(loginDTO.Email);
            if (user == null)
                return Result.Failure(AuthErrorMessage.UserCannotFound);

            var check = await appUserRepository.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!check)
                return Result.Failure(AuthErrorMessage.PasswordNotCorrect);

            try
            {
                await appUserRepository.SignInAsync(user, loginDTO.RememberMe);
            }
            catch
            {
                return Result.Failure(AuthErrorMessage.LoginFailed);
            }

            return Result.Success();
        }
    }
}
