using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MessengerApp.Core.DTO.Authorization;
using MessengerForm.Extensions;
using MessengerForm.Services.Abstraction;

namespace MessengerForm
{
    public class AuthInterceptor : DelegatingHandler
    {
        private readonly IAccountService _accountService;
        
        private readonly ITokenStorage _jsonFileTokenStorage;
        
        private static readonly SemaphoreSlim SemaphoreSlim = new(1);

        public AuthInterceptor(IAccountService accountService, ITokenStorage jsonFileTokenStorage)
        {
            _accountService = accountService;
            _jsonFileTokenStorage = jsonFileTokenStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await SemaphoreSlim.WaitAsync(cancellationToken);

            try
            {
                var token = await _jsonFileTokenStorage.GetToken();

                if (token.IsExpired())
                {
                    token = await _accountService
                        .RefreshAccessToken(new RefreshTokenDto(token.Token));

                    await _jsonFileTokenStorage.SaveToken(token);
                }
                
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

                var response = await base.SendAsync(request, cancellationToken);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = await _accountService
                        .RefreshAccessToken(new RefreshTokenDto(token.Token));

                    await _jsonFileTokenStorage.SaveToken(token);

                    request.Headers.Add("Authorization", $"Bearer {token.Token}");
                }

                return await base.SendAsync(request, cancellationToken);
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }
    }
}