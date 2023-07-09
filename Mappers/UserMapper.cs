<<<<<<< HEAD
﻿using LojaFlamengoApi.BaseResponses;  
=======
﻿using LojaFlamengoApi.BaseResponses;
>>>>>>> 73c4b2edec356b09b316ebc8e976d041fd52d3ac
using LojaFlamengoApi.Handlers.RegisterUser;
using LojaFlamengoApi.Handlers.UpdateUser;
using LojaFlamengoApi.Models;
using System.Runtime.CompilerServices;

namespace LojaFlamengoApi.Mappers
{
    public static class UserMapper
    {
        public static UserResponse ToUserResponse(this User user) =>
            new UserResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserToken = user.UserToken,
            };


        public static User ToUser(this RegisterUserRequest request) =>
            new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Cpf = request.Cpf,
                Email = request.Email,
                Phone = request.Phone
            };

        public static User ToUser(this UpdateUserRequest request) =>
           new User()
           {
               FirstName = request.FirstName,
               LastName = request.LastName,
               Email = request.Email,
               Phone = request.Phone,
           };
    }
}
