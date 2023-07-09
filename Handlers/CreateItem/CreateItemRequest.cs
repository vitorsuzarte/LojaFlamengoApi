<<<<<<< HEAD
﻿using MediatR;
=======
﻿using LojaFlamengoApi.BaseResponses;
using MediatR;
>>>>>>> 73c4b2edec356b09b316ebc8e976d041fd52d3ac
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
