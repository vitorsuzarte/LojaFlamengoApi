using LojaFlamengoApi.BaseResponses;
using MediatR;

namespace LojaFlamengoApi.Handlers.ListOrder
{
   public class ListOrderRequest : IRequest<List<OrderResponse>>
   {
        public long UserId { get; set; }
   }
}