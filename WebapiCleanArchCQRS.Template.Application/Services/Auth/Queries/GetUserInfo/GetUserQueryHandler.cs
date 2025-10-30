using MediatR;
using WebapiCleanArchCQRS.Template.Application.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebapiCleanArchCQRS.Template.Application.Services.Auth.Queries.GetUserInfo
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserInfoDTO>
    {
        public async Task<UserInfoDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = request.user;

            var claims = user.Claims.Where(c => c.Type != ClaimTypes.Role && !c.Type.StartsWith("Permission"))
              .Select(c => new KeyValuePair<string, string>(c.Type, c.Value)).ToList();

            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();
            var json = JsonSerializer.Serialize(roles);

            return new UserInfoDTO
            {
                IsAuthenticated = user.Identity!.IsAuthenticated,
                UserName = user.Identity.Name,
                ExposedClaims = claims,
                Json = json
                //Optionally: filter the claims you want to expose to the client
                //.Where(c => c.Type == "test-claim")

            };
        }
    }
}
