using LojaFlamengoApi.BaseResponses;
using LojaFlamengoApi.Handlers.DeleteUser;
using LojaFlamengoApi.Handlers.LoginUser;
using LojaFlamengoApi.Handlers.LogoutUser;
using LojaFlamengoApi.Handlers.RegisterUser;
using LojaFlamengoApi.Handlers.ResetUserPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaFlamengoApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterUserRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login(LoginUserRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout(LogoutUserRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{UserId}/deactivate")]
        public async Task<ActionResult> DeactivateUser([AsParameters] DeleteUserRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult> ResetPassword(ResetUserPasswordRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}