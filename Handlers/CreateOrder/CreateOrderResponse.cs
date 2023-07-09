using LojaFlamengoApi.BaseResponses;

namespace LojaFlamengoApi.Handlers.CreateOrder
{
   public class ListOrderResponse
   {
        public List<ItemResponse> Items { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
