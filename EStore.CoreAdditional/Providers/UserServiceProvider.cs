using CoreAdditional.Utils;
using Estore.Clients.Clients;
using Estore.Core.HTTP.Base;
using Estore.Models.DataModels.User;
using Estore.Models.Enum;
using Estore.Models.Request.User;
using Microsoft.Extensions.Configuration;

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

        public async Task<UserModel> RegisterCustomer()
        {
            var request = _userGenerator.GenerateRegisterNewUserRequest();
            var response = await RegisterValidUser(request);
            return new UserModel
            {
                Id = response.Body,
                MainInfo = new CustomerUserMainInfo
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate
                },
                Credentials = new UserCredentials
                {
                    Email = request.Email,
                    Password = request.Password,
                    Role = UserRole.Customer
                }
            };
        }

        public async Task<CommonResponse<string>> Login(string email, string password)
        {
            var request = _userGenerator.GenerateLoginRequest(email, password);
            return await _userServiceClient.Login(request);
        }

        public async Task<CommonResponse<string>> LoginAsAdmin()
        {
            var request = _userGenerator.GenerateLoginRequest(
                _configuration["AdminCredentials:email"],
                _configuration["AdminCredentials:password"]);
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
