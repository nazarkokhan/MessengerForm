using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MessengerApp.Core.DTO;
using MessengerApp.Core.DTO.Authorization;
using MessengerApp.Core.DTO.User;
using MessengerForm.DTO;
using MessengerForm.DTO.Authorization;
using MessengerForm.DTO.Authorization.Reset;
using MessengerForm.DTO.User;
using MessengerForm.Services.Abstraction;

namespace MessengerForm.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateUserAndSendEmailTokenAsync(
            RegisterDto register
        )
        {
            var urn = $"account";

            var json = JsonSerializer.Serialize(register);

            var response = await _httpClient
                .PostAsync(
                    urn,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

            response.EnsureSuccessStatusCode();
        }

        public async Task<string> ConfirmRegistrationWithTokenAsync(
            string token, string userId)
        {
            var urn = $"account/{token}/{userId}";

            var response =
                await _httpClient.GetAsync(urn);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<string>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }

        public async Task<TokenDto> GetAccessAndRefreshTokensAsync(
            LogInUserDto userInput)
        {
            var urn = $"account";

            var response =
                await _httpClient.GetAsync(urn);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TokenDto>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }
        
        public async Task<TokenDto> RefreshAccessToken(
            RefreshTokenDto refreshTokenDto)
        {
            var urn = $"account";

            var response =
                await _httpClient.GetAsync(urn);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TokenDto>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }

        public async Task<ProfileDto> GetProfileAsync(
            int userId)
        {
            var urn = $"account/{userId}";

            var response =
                await _httpClient.GetAsync(urn);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ProfileDto>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }

        public async Task<UserDto> EditUserAsync(
            int id, EditUserDto editUserDto
        )
        {
            var urn = $"account/{id}";

            var json = JsonSerializer.Serialize(editUserDto);

            var response = await _httpClient
                .PutAsync(
                    urn,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<UserDto>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }

        public async Task SendEmailResetTokenAsync(
            int userId, ResetEmailDto resetEmailDto)
        {
            var urn = $"account/{userId}";

            var json = JsonSerializer.Serialize(resetEmailDto);

            var response = await _httpClient
                .PutAsync(
                    urn,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

            response.EnsureSuccessStatusCode();
        }

        public async Task ResetEmailAsync(
            int userId, string token, string newEmail)
        {
            var urn = $"account/{userId}/{token}/{newEmail}";

            var response =
                await _httpClient.GetAsync(urn);

            response.EnsureSuccessStatusCode();
        }

        public async Task SendPasswordResetTokenAsync(
            ResetPasswordDto resetPasswordDto)
        {
            var urn = $"account";

            var json = JsonSerializer.Serialize(resetPasswordDto);

            var response = await _httpClient
                .PutAsync(
                    urn,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

            response.EnsureSuccessStatusCode();
        }

        public async Task ResetPasswordAsync(
            TokenPasswordDto tokenPasswordDto)
        {
            var urn = $"account";

            var json = JsonSerializer.Serialize(tokenPasswordDto);

            var response = await _httpClient
                .PutAsync(
                    urn,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

            response.EnsureSuccessStatusCode();
        }

        public async Task<Pager<UserDto>> GetUsersInChatAsync(
            int userId, int chatId, string search, int page, int items)
        {
            var urn = $"account/{userId}/{chatId}";

            if (!string.IsNullOrWhiteSpace(search))
                urn += $"?{nameof(search)}={search}";
            
            urn += $"?{nameof(page)}={page}";

            urn += $"?{nameof(items)}={items}";
            
            var response =
                await _httpClient.GetAsync(urn);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Pager<UserDto>>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }
    }
}