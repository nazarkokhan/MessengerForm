using Microsoft.Extensions.Configuration;

namespace MessengerForm.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetApiBaseUrl(this IConfiguration configuration)
        {
            return configuration.GetSection("Api")["BaseUrl"];
        }
    }
}