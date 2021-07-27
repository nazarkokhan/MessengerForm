﻿using System.Threading.Tasks;
using MessengerApp.Core.DTO.Chat;
using MessengerForm.DTO;

namespace MessengerForm.Services.Abstraction
{
    public interface IChatService
    {
        Task<Pager<ChatDto>> GetChatsPageAsync(
            string? search, int page, int items);
        
        Task<Pager<ChatDto>> GetUserChatsPageAsync(
            int userId, string? search, int page, int items);

        Task<ChatDto> AddUserInChatAsync(
            int userId, AddUserInChatDto addUserInChatDto);

        Task<ChatDto> GetChatAsync(
            int id);
        
        Task<ChatDto> CreateChatAsync(
            int userId, CreateChatDto createChatDto);

        Task<ChatDto> EditChatAsync(
            int userId, EditChatDto editChatDto);
        
        Task DeleteChatAsync(
            int userId, int id);
    }
}