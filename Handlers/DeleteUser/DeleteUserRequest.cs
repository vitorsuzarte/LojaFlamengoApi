using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LojaFlamengoApi.Handlers.DeleteUser
{
   public class DeleteUserRequest : IRequest<Unit>
   {
      [Required]
        public long UserId { get; set; }
    }
}
