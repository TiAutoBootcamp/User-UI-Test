

using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UserServiceAPI.Models.Requests;
using UserServiceAPI.Models.Responses;
using WalletServiceAPI.Models.Requests;
using WalletServiceAPI.Models.Responses;
using UserUITest.Pages;
using WalletServiceAPI.Models.Responses.Base;

namespace UserUITest
{
    public  class DataContext
    {
        private const bool DEFAULT_USER_STATUS = false;
        public int InitialUserId;
        public int SecondUserId;
        public double ChargeAmount;
        public double ChargeAmountRevert;


        public WalletCommonResponse<Guid> ReverseTransactionStatusResponse;
        public Guid SecondUserIdTransaction;

        public RegisterUserRequest CreateUserRequest;
        public CommonResponse<int> CreateUserResponse;
        public CommonResponse<object> SetUserStatusResponse;
        public bool UserStatus = DEFAULT_USER_STATUS;
        public Guid UserIdTransaction;
        public Guid RevertUserIdTransaction;
        
        public WalletCommonResponse<decimal> GetBalanceResponse;
        public WalletCommonResponse<Guid> ChargeResponse;

        public IWebDriver Driver { get; set; }
        public UserPage UserPage { get; set; }

        public BasePage CurrentPage { get; set; }
        public UserInfo UserInfo { get; internal set; }
        public List<string> TittleModalFields;
        public TransactionInfo TransactionInfo { get; internal set; }
        public TransactionInfo RevertTransactionInfo { get; internal set; }
    }
}
