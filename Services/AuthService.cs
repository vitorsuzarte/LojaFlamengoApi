using LojaFlamengoApi.Models;
using LojaFlamengoApi.Services.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FindMe.Domain.Services
{
   public class AuthService : IAuthService
   {
      public IConfiguration _configuration { get; }

      public AuthService(IConfiguration configuration)
      {
         _configuration = configuration;
      }

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
