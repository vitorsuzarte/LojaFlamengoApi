using LojaFlamengoApi.BaseResponses;

namespace LojaFlamengoApi.Handlers.RegisterUser
{
    public class RegisterUserResponse : UserResponse
    {
        public RegisterUserResponse(UserResponse response) : base(response) { }
    }
}
