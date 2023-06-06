using LojaFlamengoApi.BaseResponsess;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LojaFlamengoApi.Handlers.CreateItem
{
   public class CreateItemRequest : IRequest<Unit>
   {
      [Required]
      public string Description { get; set; }

      [Required]
      public double Price { get; set; }

      [Required]
      public string Tag { get; set; }

      [Required]
      public string Image { get; set; }

   }
}
