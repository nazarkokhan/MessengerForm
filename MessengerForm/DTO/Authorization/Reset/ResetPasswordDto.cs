using System.ComponentModel.DataAnnotations;

namespace MessengerForm.DTO.Authorization.Reset
{
    public class ResetPasswordDto
    {
        public ResetPasswordDto(string email)
        {
            Email = email;
        }

        [DataType(DataType.EmailAddress)] 
        public string Email { get; }
    }
}