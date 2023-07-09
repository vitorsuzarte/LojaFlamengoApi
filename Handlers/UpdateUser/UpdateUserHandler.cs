using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        public readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = request.ToUser();

            var updatedUser = await _userRepository.UpdateUser(user);

            return new UpdateUserResponse(updatedUser.ToUserResponse());
        }
    }
}
