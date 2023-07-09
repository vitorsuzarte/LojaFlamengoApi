using LojaFlamengoApi.Models;

namespace LojaFlamengoApi.Repositories.Interfaces
{
   public interface IItemRepository
    {
        public Task<Item> GetItemById(long itemId);
        public Task<IEnumerable<Item>> ListItems(int pages = 1, int itemsPerPage = 50);
        public Task UpdateItem(long id, Item item);
        public Task CreateItem(Item item);
        public Task DeleteItem(long itemId);
    }
}
