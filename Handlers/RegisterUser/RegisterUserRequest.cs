using LojaFlamengoApi.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LojaFlamengoApi.Handlers.RegisterUser
{
    public class RegisterUserRequest : IRequest<RegisterUserResponse>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
