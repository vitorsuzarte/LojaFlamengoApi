using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LojaFlamengoApi.Handlers.CreateOrder
{
   public class CreateOrderRequest : IRequest<Unit>
    {
        [Required]
        public long UserId { get; set; }
        
        [Required]
        public List<long> PurchasedItemsIds { get; set; }
        
        [Required]
        public DateTime PurchaseTime { get; set; }
    }
}
