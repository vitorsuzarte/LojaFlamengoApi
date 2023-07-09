using LojaFlamengoApi.Models;
using LojaFlamengoApi.Services.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
<<<<<<< HEAD
using System.Security.Claims;
using System.Security.Cryptography;
=======

using LojaFlamengoApi.Models;
using LojaFlamengoApi.Services.Interfaces;
>>>>>>> 73c4b2edec356b09b316ebc8e976d041fd52d3ac

namespace LojaFlamengoApi.Services
{
   public class AuthService : IAuthService
   {
      public IConfiguration _configuration { get; }

      public AuthService(IConfiguration configuration)
      {
         _configuration = configuration;
      }

<<<<<<< HEAD
      public void CreatePasswordHash(string password, out byte[] passwodHash, out byte[] passwordSalt)
      {
         using (var hmac = new HMACSHA512())
         {
            passwordSalt = hmac.Key;
            passwodHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
         }
      }

      public bool VerifyPassswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
      {
         using (var hmac = new HMACSHA512(passwordSalt))
         {
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
         }
      }

      public string CreateToken(User user)
      {
         List<Claim> claims = new List<Claim>
=======
        // public async Task<UserAuthResponse> Login(UserLoginRequest request)
        // {
        //     var user = await _userRepository.GetUser(request.Username);

        //     if (user is null)
        //     {
        //         throw new Exception("Usuário não encontrado!");
        //     }

        //     if (!VerifyPassswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        //     {
        //         throw new Exception("Senha incorreta!");
        //     }

        //     try
        //     {
        //         var userToken = CreateToken(user);
        //         await _userRepository.AssignToken(request.Username, userToken);
        //         user.UserToken = userToken;
        //         return user.ToUserResponse();
        //     }
        //     catch (Exception ex)
        //     {
        //         throw;
        //     }
        // }

        // public async Task Logout(long id)
        // {
        //     //validar a request aqui

        //     var user = await _userRepository.GetUser(username);

        //     if (user is null)
        //         throw new Exception("Usuário não encontrado!");

        //     if (String.IsNullOrEmpty(user.UserToken))
        //         throw new Exception("Usuário não está logado!");

        //     await _userRepository.Logout(username);

        // }

        // public async Task<UserAuthResponse> Register(UserRegisterRequest request)
        // {
        //     try
        //     {
        //         request.Validate();

        //         CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalet);

        //         var user = request.ToUser();
        //         user.PasswordHash = passwordHash;
        //         user.PasswordSalt = passwordSalet;
        //         user.UserToken = CreateToken(user);

        //         await _userRepository.CreateUser(user);

        //         return user.ToUserResponse();
        //     }
        //     catch (Exception ex)
        //     {
        //         throw;
        //     }
        // }

        // public async Task ResetPassword(UserResetPasswordRequest request)
        // {
        //     //validar a request aqui

        //     var user = await _userRepository.GetUser(request.Username);

        //     if (user is null)
        //         throw new Exception("Usuário não encontrado!");

        //     CreatePasswordHash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalet);

        //     await _userRepository.ResetPassword(request.Username, passwordHash, passwordSalet);
        // }


        public void CreatePasswordHash(string password, out byte[] passwodHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwodHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPassswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
>>>>>>> 73c4b2edec356b09b316ebc8e976d041fd52d3ac
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "User")
            };
         var key = new SymmetricSecurityKey(System.Text.Encoding
             .UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

         var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

         var token = new JwtSecurityToken(
             claims: claims,
             expires: DateTime.Now.AddDays(1),
             signingCredentials: cred);

         var jwt = new JwtSecurityTokenHandler().WriteToken(token);
         return jwt;
      }
   }
}
