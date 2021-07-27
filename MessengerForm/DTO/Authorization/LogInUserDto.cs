using System.ComponentModel.DataAnnotations;

namespace MessengerForm.DTO.Authorization
{
    public class LogInUserDto
    {
        public LogInUserDto(string? email, string? password)
        {
            Email = email;
            Password = password;
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; }
    }
}