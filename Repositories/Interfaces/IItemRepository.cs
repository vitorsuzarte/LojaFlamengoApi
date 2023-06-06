using LojaFlamengoApi.Models;

namespace LojaFlamengoApi.Repositories.Interfaces
{
   public interface IItemRepository
   {
      public Task<Item> GetItemById(long itemId);
      public Task<IEnumerable<Item>> ListItems(int itemsPerPage, int pages);
      public Task UpdateItem(Item item);
      public Task CreateItem(Item item);
      public Task DeleteItem(long itemId);
   }
}
