using LojaFlamengoApi.BaseResponses;
using LojaFlamengoApi.Handlers.CreateOrder;
using LojaFlamengoApi.Models;

namespace LojaFlamengoApi.Mappers
{
   public static class OrderMapper
   {
        public static Order toOrder(this CreateOrderRequest value) =>
            new Order()
            {
                PurchaseTime = value.PurchaseTime,
                UserId = value.UserId,
            };
    }
}
