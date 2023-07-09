using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Models;
using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.ListItems
{
    public class ListItemsHandler : IRequestHandler<ListItemsRequest, List<ListItemsResponse>>
    {
        public readonly IItemRepository _itemRepository;

        public ListItemsHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<ListItemsResponse>> Handle(ListItemsRequest request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.ListItems(request.ItemsPerPage, request.Pages);
            return items
               .Select(i => new ListItemsResponse(i.ToItemResponse()))
               .ToList();
        }
    }
}
