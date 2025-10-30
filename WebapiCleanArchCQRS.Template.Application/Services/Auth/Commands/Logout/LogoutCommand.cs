using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebapiCleanArchCQRS.Template.Shared.Results;

namespace WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Logout
{
    public class LogoutCommand : IRequest<Result>
    {
    }
}
