using MediatR;
using WebapiCleanArchCQRS.Template.Application.DTOs.AuthDTOs;
using WebapiCleanArchCQRS.Template.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Login;
using WebapiCleanArchCQRS.Template.Shared.Helpers.ErrorMessages;
using WebapiCleanArchCQRS.Template.Shared.Results;
using WebapiCleanArchCQRS.Template.Domain.Interfaces.AppUsers;


namespace WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Register
{
    
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IMediator mediator;

        public RegisterCommandHandler(IAppUserRepository appUserRepository , IMediator mediator)
        {
            this.appUserRepository = appUserRepository;
            this.mediator = mediator;
        }
        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            #region Register
            var registerDTO = request.registerDTO;

            var newUser = new AppUser
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email
            };

            var result = await appUserRepository.CreateAsync(newUser, registerDTO.Password);

            if (!result.Succeeded)
                return Result.Failure(AuthErrorMessage.RegisterFailed);
            #endregion

            #region Login
            var newLogin = new LoginDTO
            {
                Email = registerDTO.Email,
                Password = registerDTO.Password,
            };


            try
            {
                await appUserRepository.SignInAsync(newUser, newLogin.RememberMe);
            }
            catch
            {
                return Result.Failure(AuthErrorMessage.LoginFailed);
            }
            #endregion


            return Result.Success();
        }
    }
}
