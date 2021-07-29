using System.Threading.Tasks;
using MessengerApp.Core.DTO.Authorization;
using MessengerForm.DTO.Authorization;

namespace MessengerForm.Services.Abstraction
{
    public interface ITokenStorage
    {
        Task<TokenDto> GetToken();
        
        Task SaveToken(TokenDto tokenDto);
    }
}