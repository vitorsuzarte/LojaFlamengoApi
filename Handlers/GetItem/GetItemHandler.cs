using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.GetItem
{
    public class GetItemHandler : IRequestHandler<GetItemRequest, GetItemResponse>
    {
        public readonly IItemRepository _itemRepository;

        public GetItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<GetItemResponse> Handle(GetItemRequest request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetItemById(request.ItemId);
            return new GetItemResponse(item.ToItemResponse());
        }
    }
}
