using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.DeleteItem
{
   public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, Unit>
   {
      public readonly IItemRepository _itemRepository;

      public DeleteItemHandler(IItemRepository itemRepository)
      {
         _itemRepository = itemRepository;
      }

      public async Task<Unit> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
      {
         await _itemRepository.DeleteItem(request.ItemId);
         return Unit.Value;
      }
   }
}
