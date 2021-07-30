﻿using System.Threading.Tasks;
using MessengerApp.Core.DTO.Message;
using MessengerForm.DTO;
using MessengerForm.DTO.Message;

namespace MessengerForm.Services.Abstraction
{
    public interface IMessageService
    {
        Task<Pager<MessageDto>> GetMessagesInChatPageAsync(
            int userId, int chatId, string search = null, int page = 1, int items = 5);

        Task<MessageDto> CreateMessageAsync(
            int userId, int chatId, CreateMessageDto createMessageDto);

        Task<MessageDto> EditMessageAsync(
            int userId, EditMessageDto editMessageDto);

        Task DeleteMessageAsync(
            int userId, long messageId);
    }
}