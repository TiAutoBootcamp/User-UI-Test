using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletServiceAPI.Models.Responses.Base;

namespace WalletServiceAPI.Extensions
{
    public static class CommonResponseExtensions
    {
        public static async Task<WalletCommonResponse<T>> ToCommonResponse<T>(this HttpResponseMessage message)
        {
            string responseBody = await message.Content.ReadAsStringAsync();

            var commonResponse = new WalletCommonResponse<T>
            {
                Status = message.StatusCode,
                Content = responseBody
            };

            try
            {
                commonResponse.Body = JsonConvert.DeserializeObject<T>(responseBody);
            }
            catch (JsonReaderException exception)
            {
            }

            return commonResponse;
        }
    }
}