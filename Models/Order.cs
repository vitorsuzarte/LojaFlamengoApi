namespace LojaFlamengoApi.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string PurchasedItemsIds { get; set; }
        public DateTime PurchaseTime { get; set; }
        public long UserId { get; set; }
    }
}
