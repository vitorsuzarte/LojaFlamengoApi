using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Repositories.Interfaces;
using LojaFlamengoApi.Services.Interfaces;
using LojaFlamengoApi.Validator;
using MediatR;

namespace LojaFlamengoApi.Handlers.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
        public IAuthService _authService;
        public readonly IUserRepository _userRepository;

        public RegisterUserHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalet);

                var user = request.ToUser();
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalet;
                user.UserToken = _authService.CreateToken(user);
                user.IsActive = true;

                await _userRepository.CreateUser(user);

                return new RegisterUserResponse(user.ToUserResponse());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
