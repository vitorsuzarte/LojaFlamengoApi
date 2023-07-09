using LojaFlamengoApi.BaseResponses;
using LojaFlamengoApi.Mappers;
using LojaFlamengoApi.Models;
using LojaFlamengoApi.Repositories;
using LojaFlamengoApi.Repositories.Interfaces;
using MediatR;

namespace LojaFlamengoApi.Handlers.ListOrder
{
   public class ListOrderHandler : IRequestHandler<ListOrderRequest, List<OrderResponse>>
    {
        private readonly OrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;

        public ListOrderHandler(OrderRepository orderRepository, IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        public async Task<List<OrderResponse>> Handle(ListOrderRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Order> orders;

            try
            {
                orders = (await _orderRepository.ListOrders(request.UserId));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao listar os pedidos do usuário", ex);
            }

            List<OrderResponse> response = new List<OrderResponse>();

            foreach (Order order in orders)
            {
                OrderResponse orderResponse = new OrderResponse(order);
                var purchasedItemsIds = getItemsList(order.PurchasedItemsIds);
                IEnumerable<Item> items;                
                
                try
                {
                    items = await _itemRepository.ListItems();

                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Erro ao listar os pedidos do usuário", ex);
                }

                var itemsInOrder = items.Where(x => purchasedItemsIds.Contains(x.Id)).ToList();
                orderResponse.Total = getTotalOrder(itemsInOrder);
                orderResponse.Items = itemsInOrder.Select(x => x.ToItemResponse()).ToList();
                response.Add(orderResponse);
            }

            return response;
        }

        private List<long> getItemsList(string purchasedItemsIds)
        {
            List<long> ids = new List<long>();
            string[] idsString = purchasedItemsIds.Trim('[', ']').Split(',');

            foreach (var id in idsString)
            {
                long val = long.Parse(id);
                ids.Add(val);
            }

            return ids;
        }

        private double getTotalOrder(IEnumerable<Item> items)
        {
            return items.Sum(item => item.Price);
        }
   }
}
