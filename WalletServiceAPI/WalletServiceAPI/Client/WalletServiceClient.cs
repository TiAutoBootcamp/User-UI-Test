using Newtonsoft.Json;
using System;
using System.Text;
using WalletServiceAPI.Extensions;
using WalletServiceAPI.Models.Requests;
using WalletServiceAPI.Models.Responses.Base;

namespace WalletServiceAPI.Client
{
    public class WalletServiceClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = "https://walletservice-uat.azurewebsites.net";

        public async Task<WalletCommonResponse<decimal>> GetBalance(Int32 userId)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/Balance/GetBalance?userId={userId}"),
            };
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            return await response.ToCommonResponse<decimal>();
        }

        public async Task<WalletCommonResponse<Guid>> BalanceCharge(BalanceChargeRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseUrl}/Balance/Charge"),
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);            

            return await response.ToCommonResponse<Guid>();
        }

        public async Task<WalletCommonResponse<Guid>> RevertTransaction(Guid userId)
        {
            var getUserStatusRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_baseUrl}/Balance/RevertTransaction?transactionId={userId}")
            };

            HttpResponseMessage response = await _httpClient.SendAsync(getUserStatusRequest);

            return await response.ToCommonResponse<Guid>();
        }

        public async Task<WalletCommonResponse<string>> GetTransactions(int userId)
        {
            var getProductInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/Balance/GetTransactions?userId={userId}")
            };

            HttpResponseMessage response = await _httpClient.SendAsync(getProductInfoRequest);
            return await response.ToCommonResponse<string>();
        }
    }
}
