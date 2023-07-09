using MediatR;

namespace LojaFlamengoApi.Handlers.ResetUserPassword
{
    public class ResetUserPasswordHandler : IRequestHandler<ResetUserPasswordRequest, Unit>
    {
        public async Task<Unit> Handle(ResetUserPasswordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
