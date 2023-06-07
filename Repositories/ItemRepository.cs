using Dapper;
using LojaFlamengoApi.Models;
using LojaFlamengoApi.Repositories.Interfaces;
using System.Data;

namespace LojaFlamengoApi.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDbConnection _connection;

        public ItemRepository(SqlConnectionProvider connectionProvider)
        {
            _connection = connectionProvider.GetDbConnection;
        }

        public async Task CreateItem(Item item)
        {
            var query = @"INSERT INTO items 
                          (description, price, tag, image, isActive)
                          values 
                          (@description, @price, @tag, @image, @isActive)";
            await _connection.QueryAsync(query, new
            {
                item.Description,
                item.Price,
                item.Tag,
                item.Image,
                item.IsActive,
            });
        }

        public async Task DeleteItem(long itemId)
        {
            var query = @"UPDATE items SET
                          isActive = false
                          WHERE Id = @itemId";
            await _connection.QueryAsync(query, new
            {
                itemId,
            });
        }

        public async Task<Item> GetItemById(long itemId)
        {
            var query = @"SELECT * FROM items where id = @ItemId";
            var item = await _connection.QueryFirstAsync<Item>(query, new
            {
                itemId
            });
            return item;
        }

        public async Task<IEnumerable<Item>> ListItems(int itemsPerPage, int pages)
        {
            var query = @"SELECT * FROM items";
            var items = await _connection.QueryAsync<Item>(query);
            var itemsToSkip = itemsPerPage * (pages - 1);
            return items
               .Skip(itemsToSkip)
               .Take(itemsPerPage);
        }

        public async Task UpdateItem(long id, Item item)
        {
            var query = @"UPDATE items SET
                          description = @description,
                          price = @price,
                          tag = @tag,                           
                          image = @image
                          WHERE Id = @itemId";
            await _connection.QueryAsync(query, param: new
            {
                description = item.Description,
                price = item.Price,
                tag = item.Tag,
                image = item.Image,
                itemId = id
            });
        }
    }
}
