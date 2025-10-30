using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebapiCleanArchCQRS.Template.Application.DTOs.AuthDTOs;
using WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Login;
using WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Logout;
using WebapiCleanArchCQRS.Template.Application.Services.Auth.Commands.Register;
using WebapiCleanArchCQRS.Template.Application.Services.Auth.Queries.GetUserInfo;

namespace WebapiCleanArchCQRS.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await mediator.Send(new LoginCommand { loginDTO = loginDTO });
            return result.IsSuccess? Ok(result) : BadRequest(result.Error);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var result = await mediator.Send(new RegisterCommand { registerDTO = registerDTO });
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }


        [Authorize] 
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await mediator.Send(new LogoutCommand());
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }


        [Authorize ]
        [HttpGet("UserInfo")]
        public  async Task<IActionResult> GetUserInfo()
        {
            var userInfo =  await mediator.Send(new GetUserQuery{ user = User});
            return Ok(userInfo);
        }

    }
}
