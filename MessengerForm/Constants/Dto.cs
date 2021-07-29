using MessengerForm.DTO.Authorization;

namespace MessengerForm.Constants
{
    public static class Dto
    {
        public static LogInUserDto LogInUserData()
        {
            return new(
                LoginData.Email,
                LoginData.Password
            );
        }
    }
}