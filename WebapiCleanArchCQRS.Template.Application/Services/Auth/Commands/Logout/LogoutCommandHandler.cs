using MediatR;
using WebapiCleanArchCQRS.Template.Domain.Interfaces.AppUsers;
using WebapiCleanArchCQRS.Template.Shared.Helpers.ErrorMessages;
using WebapiCleanArchCQRS.Template.Shared.Results;

namespace WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Logout
{
    internal class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result>
    {
        private readonly IAppUserRepository appUserRepository;

        public LogoutCommandHandler(IAppUserRepository appUserRepository)
        {
            this.appUserRepository = appUserRepository;
        }
        public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await appUserRepository.SignOutAsync();
            }
            catch
            {
                return Result.Failure(AuthErrorMessage.LogoutFailed);
            }
            return Result.Success();
        }
    }
}
