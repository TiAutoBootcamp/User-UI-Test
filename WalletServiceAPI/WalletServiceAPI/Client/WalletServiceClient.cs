﻿using Newtonsoft.Json;
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
    }
}