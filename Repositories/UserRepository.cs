using Dapper;
using LojaFlamengoApi.Models;
using LojaFlamengoApi.Repositories.Interfaces;
using System.Data;

namespace LojaFlamengoApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(SqlConnectionProvider connectionProvider)
        {
            _connection = connectionProvider.GetDbConnection;
        }

        public async Task Logout(string email)
        {
            var query = @"UPDATE users SET userToken = null WHERE email = @email";
            await _connection.QueryAsync(query, new
            {
                email
            });
        }

        public async Task AssignToken(string email, string userToken)
        {
            var query = @"UPDATE users SET userToken = @userToken WHERE email = @email";
            await _connection.QueryAsync(query, new
            {
                userToken,
                email
            });
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var query = @"SELECT * FROM users where email = @email";
            var user = await _connection.QueryFirstAsync<User>(query, new
            {
                email
            });
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var query = @"UPDATE users SET
                          firstName = @firstName,
                          lastName = @lastName
                          phone = @phone                          
                          email = @email
                          WHERE username = @username";

            var result = await _connection.QueryFirstAsync<User>(query, new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.Phone
            });
            return result;
        }

        public async Task CreateUser(User user)
        {
            var query = @"INSERT INTO users 
                          (firstName, lastName, cpf, email, phone, passwordHash, passwordSalt, userToken, isActive)
                          values 
                          (@firstName, @lastName, @cpf, @email, @phone, @passwordHash, @passwordSalt, @userToken, @isActive)";
            await _connection.QueryAsync(query, param: new
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                cpf = user.Cpf,
                email = user.Email,
                phone = user.Phone,
                passwordHash = user.PasswordHash,
                passwordSalt = user.PasswordSalt,
                userToken = user.UserToken,
                isActive = user.IsActive
            });
        }

        public async Task ResetPassword(string username, byte[] passwordHash, byte[] passwordSalt)
        {
            var query = @"UPDATE users SET
                          passwordHash = @passwordHash,
                          passwordSalt = @passwordSalt
                          WHERE username = @username";
            await _connection.QueryAsync(query, new
            {
                username,
                passwordHash,
                passwordSalt
            });
        }
        public async Task<User> GetUserById(long userId)
        {
            var query = @"SELECT * FROM users where id = @userId";
            var user = await _connection.QueryFirstAsync<User>(query, new
            {
                userId
            });
            return user;
        }

        public async Task DeleteUser(long userId)
        {
            var query = @"UPDATE users SET
                          isActive = false,
                          WHERE Id = @userId";
            await _connection.QueryAsync(query, new
            {
                userId,
            });
        }
    }
}
