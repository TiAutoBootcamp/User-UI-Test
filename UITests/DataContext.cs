using Core;
using OpenQA.Selenium;
using UserServiceAPI.Models.Requests;
using UserServiceAPI.Models.Responses;
using WalletServiceAPI.Models.Responses.Base;
using UserManagementServiceUITests.Pages;
using UserUITest.Pages;
using CatalogServiceAPI.Models.Requests;
using CatalogServiceAPI.Client;
using Core.Enums;

namespace UserManagementServiceUITests
{
    public class DataContext
    {
        private const bool DEFAULT_USER_STATUS = false;
        public int InitialUserId;
        public int SecondUserId;
        public double ChargeAmount;
        public double ChargeAmountRevert;
    
        public WalletCommonResponse<Guid> ReverseTransactionStatusResponse;
        public Guid SecondUserIdTransaction;

        public RegisterUserRequest CreateUserRequest;
        public CreateProductRequest ProductRequest;
        public List<CreateProductRequest> ProductRequestList;
        public CommonResponse<int> CreateUserResponse;
        public CommonResponse<object> SetUserStatusResponse;
        public bool UserStatus = DEFAULT_USER_STATUS;
        public Guid UserIdTransaction;
        public Guid RevertUserIdTransaction;

        public WalletCommonResponse<decimal> GetBalanceResponse;
        public WalletCommonResponse<Guid> ChargeResponse;

        public int NumberTransactions;
        public IWebDriver Driver { get; set; }
        public UserPage UserPage { get; set; }
        public MainPage MainPage { get; set; }

        public BasePage CurrentPage { get; set; }
        public UserInfo UserInfo { get; internal set; }
        public List<string> TittleModalFields;
        public TransactionInfo TransactionInfo { get; internal set; }
        public TransactionInfo RevertTransactionInfo { get; internal set; }

        public CatalogServiceClient CatalogServiceClient { get; set; }

        public List<DateTime> ExpectedTransactionTime { get; internal set; }
        public List<DateTime> ActualTransactionTime { get; internal set; }

        public List<Guid> ExpectedIdsTransaction { get; internal set; }
        public List<double> ExpectedAmountTransaction { get; internal set; }
        public List<string> ExpectedStatusTransaction { get; internal set; }
        public List<TransactionInfo> transactionInfos { get; internal set; }
        public List<string> ProductArticles { get; internal set; }
        public List<(CreateProductRequest, ProductStatus)> ProductRequestsAndStatuses { get; internal set; }
}
}
