using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MessengerApp.Core.DTO;
using MessengerApp.Core.DTO.Contact;
using MessengerForm.DTO;
using MessengerForm.Services.Abstraction;

namespace MessengerForm.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pager<ContactDto>> GetContactsPageAsync(
            int userId, string search, int page, int items
        )
        {
            var urn = $"message/{userId}";

            if (!string.IsNullOrWhiteSpace(search))
                urn += $"?{nameof(search)}={search}";

            urn += $"?{nameof(page)}={page}";

            urn += $"?{nameof(items)}={items}";

            var response =
                await _httpClient.GetAsync(urn);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Pager<ContactDto>>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }

        public async Task<ContactDto> GetContactAsync(
            int userId, int userContactId
        )
        {
            var urn = $"message/{userId}/{userContactId}";

            var response =
                await _httpClient.GetAsync(urn);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ContactDto>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }

        public async Task<ContactDto> CreateContactAsync(
            int userId, CreateContactDto createContactDto
        )
        {
            var urn = $"message/{userId}";

            var json = JsonSerializer.Serialize(createContactDto);

            var response = await _httpClient
                .PostAsync(
                    urn,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ContactDto>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }

        public async Task<ContactDto> EditContactAsync(
            int userId, EditContactDto editContactDto
        )
        {
            var urn = $"message/{userId}";

            var json = JsonSerializer.Serialize(editContactDto);

            var response = await _httpClient
                .PutAsync(
                    urn,
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ContactDto>(responseString,
                new JsonSerializerOptions {Converters = {new JsonStringEnumConverter()}}
            );
        }

        public async Task DeleteContactAsync(
            int userId, int contactId
        )
        {
            var urn = $"message/{userId}/{contactId}";

            var response = await _httpClient
                .DeleteAsync(
                    urn
                );

            response.EnsureSuccessStatusCode();
        }
    }
}