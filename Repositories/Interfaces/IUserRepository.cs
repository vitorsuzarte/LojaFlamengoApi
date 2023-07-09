using LojaFlamengoApi.Models;

namespace LojaFlamengoApi.Repositories.Interfaces
{
   public interface IUserRepository
   {
      public Task<User> GetUserByEmail(string email);
      public Task<User> GetUserById(long userId);
      public Task<int> CreateUser(User user);
      public Task AssignToken(string username, string userToken);
      public Task Logout(string username);
      public Task ResetPassword(string username, byte[] passwordHash, byte[] passwordSalt);
      public Task DeleteUser(long userId);
      public Task<User> UpdateUser(User user);
   }
}
