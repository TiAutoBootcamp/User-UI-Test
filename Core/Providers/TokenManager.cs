using CoreAdditional.Utils;
using Estore.Clients.Clients;
using Microsoft.Extensions.Configuration;

namespace CoreAdditional.Providers
{
    public class TokenManager
    {
        private string _token;
        private DateTime _lastTokenRefreshTime;
        private readonly TimeSpan _tokenRefreshIntervalInMinutes;
        private readonly UserClient _userServiceClient;
        private readonly IConfiguration _configuration;
        private readonly UserRequestGenerator _userGenerator;
        private SemaphoreSlim _tokenRefreshSemaphore = new SemaphoreSlim(1);

        public TokenManager(UserClient client,
           IConfiguration configuration,
           UserRequestGenerator userGenerator)
        {
            _userServiceClient = client;
            _configuration = configuration;
            _tokenRefreshIntervalInMinutes = TimeSpan.FromMinutes(double.Parse(configuration["TokenRefreshIntervalInMinutes"]));
            _userGenerator = userGenerator;
        }

        public async Task<string> GetValidAdminToken()
        {
            await _tokenRefreshSemaphore.WaitAsync();

            try
            {
                if (_token == null || DateTime.Now - _lastTokenRefreshTime >= _tokenRefreshIntervalInMinutes)
                {
                    _token = await RequestNewAdminToken();
                    _lastTokenRefreshTime = DateTime.Now;
                }
            }
            finally
            {
                _tokenRefreshSemaphore.Release();
            }

            return _token;
        }

        private async Task<string> RequestNewAdminToken()
        {
            var request = _userGenerator.GenerateLoginRequest
                (_configuration["AdminCredentials:email"], _configuration["AdminCredentials:password"]);
            var response = await _userServiceClient.Login(request);
            if (response.IsSuccesfull)
            {
                _token = response.Body;
                return _token;
            }
            else
            {
                throw new Exception($"Failed to get token: Status code: {response.StatusCode}; Content: {response.Content}");
            }
        }
    }
}
