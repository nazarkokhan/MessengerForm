using System;
using MessengerForm.DTO.Authorization;

namespace MessengerForm.Extensions
{
    public static class Extension
    {
        public static bool IsExpired(this TokenDto tokenDto)
        {
            return DateTime.UtcNow >= tokenDto.TokenExpTime;
        }
    }
}