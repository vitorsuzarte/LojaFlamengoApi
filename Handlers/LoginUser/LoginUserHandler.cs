using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Repositories.Interfaces;
using LojaFlamengoApi.Services.Interfaces;
using LojaFlamengoApi.Validator;
using MediatR;

namespace LojaFlamengoApi.Handlers.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        public IAuthService _authService;
        public readonly IUserRepository _userRepository;

        public LoginUserHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                var user = await _userRepository.GetUserByEmail(request.Email);

                if (user is null)
                    throw new Exception("Usuário não encontrado!");

                if (!_authService.VerifyPassswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    throw new Exception("Senha incorreta!");

                if (user.UserToken is not null)
                    return new LoginUserResponse(user.ToUserResponse(), user.Email);

                var userToken = _authService.CreateToken(user);
                await _userRepository.AssignToken(request.Email, userToken);
                user.UserToken = userToken;
                user.IsActive = true;

                return new LoginUserResponse(user.ToUserResponse(), user.Email);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
