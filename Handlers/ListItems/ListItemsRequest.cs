using MediatR;

namespace LojaFlamengoApi.Handlers.ListItems
{
   public class ListItemsRequest : IRequest<List<ListItemsResponse>>
   {
        public int ItemsPerPage { get; set; }
        public int Pages { get; set; }
    }
}
