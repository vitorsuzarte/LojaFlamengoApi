using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.DeleteUser
{
   public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Unit>
   {
      public readonly IUserRepository _userRepository;

      public DeleteUserHandler(IUserRepository userRepository)
      {
         _userRepository = userRepository;
      }

      public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
      {
         await _userRepository.DeleteUser(request.UserId);
         return Unit.Value;
      }
   }
}
