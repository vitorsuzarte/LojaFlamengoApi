using MediatR;

namespace LojaFlamengoApi.Handlers.UpdateUser
{
   public class UpdateUserRequest : IRequest<UpdateUserResponse>
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public string Phone { get; set; }
   }
}

