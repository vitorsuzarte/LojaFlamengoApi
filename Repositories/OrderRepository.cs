using Dapper;
using LojaFlamengoApi.Models;
using System.Data;

namespace LojaFlamengoApi.Repositories
{
    public class OrderRepository
    {
        private readonly IDbConnection _connection;

        public OrderRepository(SqlConnectionProvider connectionProvider)
        {
            _connection = connectionProvider.GetDbConnection;
        }

        public async Task CreateOrder(Order order)
        {
            var query = @"INSERT INTO orders 
                          (PurchaseTime, PurchasedItemsIds, userId)
                          values 
                          (@purchaseTime, @purchasedItemsIds, @userId)";
            await _connection.QueryAsync(query, new
            {
                purchasedItemsIds = order.PurchasedItemsIds.ToString(),
                purchaseTime = order.PurchaseTime,
                userId = order.UserId
            });
        }

        public async Task<IEnumerable<Order>> ListOrders(long userId)
        {
            var query = @"select * from orders where userId = @userId";
            var orders = await _connection.QueryAsync<Order>(query, new
            {
                userId
            });
            return orders;
        }
    }
}
