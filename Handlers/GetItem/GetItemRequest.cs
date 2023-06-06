using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LojaFlamengoApi.Handlers.GetItem
{
   public class GetItemRequest : IRequest<GetItemResponse>
   {
      [Required]
        public long ItemId { get; set; }
    }
}
