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
            var item = await _itemRepository.GetItemById(request.ItemId);
            if (item is null)
                throw new ArgumentException("Item não encontrado");

            var newItem = request.ToItem();
            await _itemRepository.UpdateItem(item.Id, newItem);
            return Unit.Value;
        }
    }
}
