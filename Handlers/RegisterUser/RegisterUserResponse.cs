using LojaFlamengoApi.BaseResponses;

namespace LojaFlamengoApi.Handlers.RegisterUser
{
   public class RegisterUserResponse : UserResponse
   {
      public string Email { get; set; }
      public RegisterUserResponse(UserResponse response, String email) : base(response)
      {
         Email = email;
      }
   }
}
