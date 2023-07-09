using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LojaFlamengoApi.Handlers.LogoutUser
{
   public class LogoutUserRequest : IRequest<Unit>
   {
      [Required]  
      public long UserId { get; set; }
    }
}
