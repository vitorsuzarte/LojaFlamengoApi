﻿namespace LojaFlamengoApi.BaseResponses
{
    public class UserResponse
    {
        public UserResponse() { }

        public UserResponse(UserResponse response)
        {
            Id = response.Id;
            FirstName = response.FirstName;
            LastName = response.LastName;
            UserToken = response.UserToken;
        }

        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserToken { get; set; }

    }
}