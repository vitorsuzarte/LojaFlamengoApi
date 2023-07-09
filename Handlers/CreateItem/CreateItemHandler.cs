using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.CreateItem
{
   public class CreateItemHandler : IRequestHandler<CreateItemRequest, Unit>
   {
      public readonly IItemRepository _itemRepository;

      public CreateItemHandler(IItemRepository itemRepository)
      {
         _itemRepository = itemRepository;
      }

      public async Task<Unit> Handle(CreateItemRequest request, CancellationToken cancellationToken)
      {
         var item = request.ToItem();
         item.IsActive = true;

         await _itemRepository.CreateItem(item);
         return Unit.Value;
      }
   }
}
