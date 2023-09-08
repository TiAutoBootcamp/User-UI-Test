﻿using Newtonsoft.Json;

using UserServiceAPI.Models.Responses;

namespace UserServiceAPI.Extensions
{
    public static class CommonResponseExtensions
    {
        public static async Task<CommonResponse<T>> ToCommonResponse<T>(this HttpResponseMessage message)
        {
            string responseBody = await message.Content.ReadAsStringAsync();

            var commonResponse = new CommonResponse<T>
            {
                StatusCode = message.StatusCode,
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
