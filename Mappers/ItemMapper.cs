using LojaFlamengoApi.BaseResponses;
<<<<<<< HEAD
using LojaFlamengoApi.Handlers.CreateItem ;
=======
using LojaFlamengoApi.Handlers.CreateItem;
>>>>>>> 73c4b2edec356b09b316ebc8e976d041fd52d3ac
using LojaFlamengoApi.Handlers.RegisterUser;
using LojaFlamengoApi.Handlers.UpdateItem;
using LojaFlamengoApi.Models;
using MediatR.NotificationPublishers;

namespace LojaFlamengoApi.Mappers
{
    public static class ItemMapper
    {
        public static Item ToItem(this CreateItemRequest value) =>
            new Item()
            {
                Description = value.Description,
                Price = value.Price,
                Tag = value.Tag,
                Image = value.Image
            };

        public static Item ToItem(this UpdateItemRequest value) =>
           new Item()
           {
               Description = value.Description,
               Price = value.Price,
               Tag = value.Tag,
               Image = value.Image
           };

        public static ItemResponse ToItemResponse(this Item value) =>
            new ItemResponse()
            {
                Id = value.Id,
                Description = value.Description,
                Price = value.Price,
                Tag = value.Tag,
                Image = value.Image,
                IsActive = value.IsActive
            };
    }
}
