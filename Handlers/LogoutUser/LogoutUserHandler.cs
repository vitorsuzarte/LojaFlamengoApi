using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.LogoutUser
{
   public class LogoutUserHandler : IRequestHandler<LogoutUserRequest, Unit>
   {

      public readonly IUserRepository _userRepository;

      public LogoutUserHandler(IUserRepository userRepository)
      {
         _userRepository = userRepository;
      }

      public async Task<Unit> Handle(LogoutUserRequest request, CancellationToken cancellationToken)
      {
         var user = await _userRepository.GetUserById(request.UserId);

         if (user is null)
            throw new Exception("Usuário não encontrado!");

         if (String.IsNullOrEmpty(user.UserToken))
            throw new Exception("Usuário não está logado!");

         await _userRepository.Logout(user.Email);

         return Unit.Value;
      }
   }
}
