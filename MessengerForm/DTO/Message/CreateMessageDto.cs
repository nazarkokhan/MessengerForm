﻿namespace MessengerForm.DTO.Message
{
    public class CreateMessageDto
    {
        public CreateMessageDto(string body)
        {
            Body = body;
        }

        public string Body { get; }
    }
}