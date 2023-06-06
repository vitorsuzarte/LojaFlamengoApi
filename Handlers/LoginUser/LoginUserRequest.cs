using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LojaFlamengoApi.Handlers.LoginUser
{
   public class LoginUserRequest : IRequest<LoginUserResponse>
   {
      [Required]
      [EmailAddress]
      public string Email { get; set; }

      [Required]
      public string Password { get; set; }
   }
}
