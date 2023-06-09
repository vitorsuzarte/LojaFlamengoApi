﻿using LojaFlamengoApi.BaseResponses;
using LojaFlamengoApi.Handlers.CreateItem;
using LojaFlamengoApi.Handlers.UpdateItem;
using LojaFlamengoApi.Models;

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
            };
    }
}
