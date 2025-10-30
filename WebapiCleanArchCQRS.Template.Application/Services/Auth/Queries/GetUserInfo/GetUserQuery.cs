using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebapiCleanArchCQRS.Template.Application.DTOs.AuthDTOs;

namespace WebapiCleanArchCQRS.Template.Application.Services.Auth.Queries.GetUserInfo
{
    public class GetUserQuery : IRequest<UserInfoDTO>
    {
        public ClaimsPrincipal user { get; set; } = null!;
    }
}
