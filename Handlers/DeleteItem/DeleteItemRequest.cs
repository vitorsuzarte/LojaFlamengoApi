using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LojaFlamengoApi.Handlers.DeleteItem
{
   public class DeleteItemRequest : IRequest<Unit>
   {
      [Required]
        public long ItemId { get; set; }
    }
}
