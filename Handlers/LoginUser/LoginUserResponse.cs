using LojaFlamengoApi.BaseResponses;

namespace LojaFlamengoApi.Handlers.LoginUser
{
    public class LoginUserResponse : UserResponse
    {
        public LoginUserResponse(UserResponse response) : base(response)
        {

        }
    }
}
