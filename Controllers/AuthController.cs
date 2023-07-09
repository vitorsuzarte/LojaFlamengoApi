using LojaFlamengoApi.Handlers.LoginUser;
using LojaFlamengoApi.Handlers.LogoutUser;
using LojaFlamengoApi.Handlers.RegisterUser;
using LojaFlamengoApi.Handlers.ResetUserPassword;
using LojaFlamengoApi.Models;
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
      public async Task<ActionResult<User>> Register(RegisterUserRequest request)
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
      public async Task<ActionResult<string>> Login(LoginUserRequest request)
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
      public async Task<ActionResult<string>> Logout(LogoutUserRequest request)
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
      public async Task<ActionResult<string>> ResetPassword(ResetUserPasswordRequest request)
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