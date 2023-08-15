using Newtonsoft.Json;
using System.Text;

namespace Core.Client
{
    public abstract class BaseClient
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl;

        protected BaseClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        protected async Task<HttpResponseMessage> SendPostRequest(string relativeUrl, object content)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_baseUrl + relativeUrl),
                Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
            };

            return await _client.SendAsync(httpRequestMessage);
        }

        protected async Task<HttpResponseMessage> SendPutRequest(string relativeUrl, object content)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(_baseUrl + relativeUrl),
                Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
            };

            return await _client.SendAsync(httpRequestMessage);
        }

        protected async Task<HttpResponseMessage> SendPutRequestWithoutContent(string relativeUrl)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(_baseUrl + relativeUrl),
            };

            return await _client.SendAsync(httpRequestMessage);
        }

        protected async Task<HttpResponseMessage> SendDeleteRequest(string relativeUrl)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_baseUrl + relativeUrl),
            };

            return await _client.SendAsync(httpRequestMessage);
        }

        protected async Task<HttpResponseMessage> SendGetRequest(string relativeUrl)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_baseUrl + relativeUrl),
            };

            return await _client.SendAsync(httpRequestMessage);
        }
    }
}
