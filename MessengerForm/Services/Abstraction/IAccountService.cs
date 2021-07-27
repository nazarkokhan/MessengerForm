using System.Threading.Tasks;
using MessengerApp.Core.DTO.User;
using MessengerForm.DTO;
using MessengerForm.DTO.Authorization;
using MessengerForm.DTO.Authorization.Reset;
using MessengerForm.DTO.User;

namespace MessengerForm.Services.Abstraction
{
    public interface IAccountService
    {
        Task CreateUserAndSendEmailTokenAsync(
            RegisterDto register);

        Task<string> ConfirmRegistrationWithTokenAsync(
            string token, string userId);
        
        Task<Token> GetAccessTokenAsync(
            LogInUserDto userInput);

        Task<ProfileDto> GetProfileAsync(
            int userId);

        Task<UserDto> EditUserAsync(
            int id, EditUserDto editUserDto);
        
        Task SendEmailResetTokenAsync(
            int userId, ResetEmailDto resetEmailDto);

        Task ResetEmailAsync(
            int userId, string token, string newEmail);

        Task SendPasswordResetTokenAsync(
            ResetPasswordDto resetPasswordDto);

        Task ResetPasswordAsync(
            TokenPasswordDto tokenPasswordDto);

        Task<Pager<UserDto>> GetUsersInChatAsync(
            int userId, int chatId, string? search, int page, int items);
    }
}