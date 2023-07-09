using LojaFlamengoApi.Models;

namespace LojaFlamengoApi.BaseResponses
{
    public class OrderResponse
    {
        public long OrderId { get; set; }
        public List<ItemResponse> Items { get; set; }
        public DateTime PurchaseTime { get; set; }
        public double Total { get; set; }

        public OrderResponse(Order order)
        {
            OrderId = order.Id;
            PurchaseTime = order.PurchaseTime;
        }
    }
}
