using System.Threading.Tasks;
using MessengerApp.Core.DTO;
using MessengerApp.Core.DTO.Contact;
using MessengerForm.DTO;

namespace MessengerForm.Services.Abstraction
{
    public interface IContactService
    {
        Task<Pager<ContactDto>> GetContactsPageAsync(
            int userId, string search, int page, int items);

        Task<ContactDto> GetContactAsync(
            int userId, int userContactId);

        Task<ContactDto> CreateContactAsync(
            int userId, CreateContactDto createContactDto);

        Task<ContactDto> EditContactAsync(
            int userId, EditContactDto editContactDto);

        Task DeleteContactAsync(
            int userId, int contactId);
    }
}