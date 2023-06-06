using LojaFlamengoApi.Handlers.LoginUser;
using LojaFlamengoApi.Handlers.RegisterUser;
using LojaFlamengoApi.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace LojaFlamengoApi.Validator
{
   public static class UserValidator
   {
      public static void Validate(this RegisterUserRequest value)
      {
         if (value.Cpf.IsInvalidCpf())
            throw new ArgumentException("Cpf Inválido");

         if (value.Phone.Length < 13)
            throw new ArgumentException("Celular Inválido");
      }

      public static void Validate(this LoginUserRequest value)
      {
         if (value.Email.IsNullOrEmpty())
            throw new ArgumentException("Email Inválido");
      }
   }
}
