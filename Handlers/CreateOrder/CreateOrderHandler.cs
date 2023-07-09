using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Repositories;
using MediatR;

namespace LojaFlamengoApi.Handlers.CreateOrder
{
   public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, Unit>
    {
        private readonly OrderRepository _orderRepository;

      public CreateOrderHandler(OrderRepository orderRepository)
      {
         _orderRepository = orderRepository;
      }

      public async Task<Unit> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var purchasedItemsIdsString = string.Join(",", request.PurchasedItemsIds);
            var order = request.toOrder();
            order.PurchasedItemsIds = purchasedItemsIdsString;
            try
            {
                await _orderRepository.CreateOrder(order);
            } catch(Exception ex)
            {
                throw new InvalidOperationException("Erro ao salvar o registro no banco de dados.", ex);
            }

            return Unit.Value;
        }
    }
}
