

using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UserServiceAPI.Models.Requests;
using UserServiceAPI.Models.Responses;
using UserUITest.Pages;

namespace UserUITest
{
    public  class DataContext
    {
        private const bool DEFAULT_USER_STATUS = false;
        public int InitialUserId;
        public int SecondUserId;

        public RegisterUserRequest CreateUserRequest;
        public CommonResponse<int> CreateUserResponse;
        public CommonResponse<object> SetUserStatusResponse;
        public bool UserStatus = DEFAULT_USER_STATUS;
        public Guid UserIdTransaction;

        public IWebDriver Driver { get; set; }
        public UserPage UserPage { get; set; }

        public BasePage CurrentPage { get; set; }
        public UserInfo UserInfo { get; internal set; }
    }
}
