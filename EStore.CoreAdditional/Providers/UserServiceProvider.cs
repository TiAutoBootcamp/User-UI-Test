using CoreAdditional.Utils;
using Estore.Clients.Clients;
using Estore.Core.HTTP.Base;
using Estore.Models.Request.User;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace CoreAdditional.Providers
{
    public class UserServiceProvider
    {
        private readonly UserClient _userServiceClient;
        private readonly UserRequestGenerator _userGenerator;
        private readonly IConfiguration _configuration;
        public UserServiceProvider(UserClient client,
           UserRequestGenerator generator,
           IConfiguration configuration)
        {
            _userServiceClient = client;
            _userGenerator = generator;
            _configuration = configuration;
        }

        public async Task<CommonResponse<int?>> RegisterValidUser(RegisterCustomerRequest request)
        {
            var commonResponse = await _userServiceClient.RegisterCustomer(request);
            return commonResponse;
        }

        public async Task<CommonResponse<string>> Login(string email, string password)
        {
            var request = _userGenerator.GenerateLoginRequest(email, password);
            return await _userServiceClient.Login(request);
        }

        public async Task<CommonResponse<EmptyModel>> DeleteExistUser(int userId, string? token = null)
        {
            var commonResponse = await _userServiceClient.DeleteUser(userId, token);
            return commonResponse;
        }

        public async Task<CommonResponse<EmptyModel>> SetUserStatus(int userId, bool status, string? token = null)
        {
            return await _userServiceClient.SetUserStatus(userId, status, token);
        }
    }
}
