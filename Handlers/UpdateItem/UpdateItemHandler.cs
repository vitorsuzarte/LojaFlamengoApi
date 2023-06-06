using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.UpdateItem
{
   public class UpdateItemHandler : IRequestHandler<UpdateItemRequest, Unit>
   {
      public readonly IItemRepository _itemRepository;

      public UpdateItemHandler(IItemRepository itemRepository)
      {
         _itemRepository = itemRepository;
      }

      public async Task<Unit> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
      {
         var item = request.ToItem();
         await _itemRepository.UpdateItem(item);
         return Unit.Value;
      }
   }
}
