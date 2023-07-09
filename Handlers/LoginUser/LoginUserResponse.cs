using LojaFlamengoApi.BaseResponses;

namespace LojaFlamengoApi.Handlers.LoginUser
{
   public class LoginUserResponse : UserResponse
   {
      public string Email { get; set; }

      public LoginUserResponse(UserResponse response, string email) : base(response)
      {
         Email = email;
      }
   }
}
