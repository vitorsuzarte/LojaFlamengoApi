using MediatR;

namespace LojaFlamengoApi.Handlers.UpdateItem
{
    public class UpdateItemRequest : IRequest<Unit>
    {
        public long ItemId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Tag { get; set; }
        public string Image { get; set; }
    }
}
