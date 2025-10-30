using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebapiCleanArchCQRS.Template.Application.DTOs.AuthDTOs;
using WebapiCleanArchCQRS.Template.Shared.Results;

namespace WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Login
{
    public class LoginCommand : IRequest<Result>
    {
        public LoginDTO loginDTO { get; set; } = null!;
    }
}
