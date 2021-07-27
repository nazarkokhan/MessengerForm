﻿namespace MessengerForm.DTO.Authorization
{
    public class ProfileDto
    {
        public ProfileDto(int id, string email)
        {
            Id = id;
            Email = email;
        }

        public int Id { get; }

        public string Email { get; }
    }
}