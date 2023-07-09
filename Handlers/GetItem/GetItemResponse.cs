using LojaFlamengoApi.BaseResponses;

namespace LojaFlamengoApi.Handlers.GetItem
{
    public class GetItemResponse : ItemResponse
    {
        public GetItemResponse(ItemResponse response) : base(response)
        {

        }
    }
}
