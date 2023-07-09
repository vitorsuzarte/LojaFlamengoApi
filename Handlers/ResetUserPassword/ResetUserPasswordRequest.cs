using System.ComponentModel.DataAnnotations;
using MediatR;

namespace LojaFlamengoApi.Handlers.ResetUserPassword
{
    public class ResetUserPasswordRequest : IRequest<Unit>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
