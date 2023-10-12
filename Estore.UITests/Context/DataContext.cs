using OpenQA.Selenium;
using UITests.Pages;
using UserManagementServiceUITests.Pages;
using Estore.Models.Request.User;
using Estore.Core.HTTP.Base;
using Estore.Models.Request.Catalog;
using Estore.Clients.Clients;
using Estore.Models.Enum;
using Estore.Models.Response.Wallet;
using CoreAdditional.Models;

namespace UITests.Context
{
    public class DataContext
    {
        private const bool DEFAULT_USER_STATUS = false;
        public int InitialUserId;
        public int SecondUserId;
        public decimal ChargeAmount;
        public decimal ChargeAmountRevert;

        public CommonResponse<Guid> ReverseTransactionStatusResponse;
        public Guid SecondUserIdTransaction;

        public RegisterCustomerRequest CreateUserRequest;
        public AddProductRequest ProductRequest;
        public List<AddProductRequest> ProductRequestList;
        public CommonResponse<int?> CreateUserResponse;
        public CommonResponse<EmptyModel> SetUserStatusResponse;
        public bool UserStatus = DEFAULT_USER_STATUS;
        public Guid UserIdTransaction;
        public Guid RevertUserIdTransaction;

        public CommonResponse<decimal> GetBalanceResponse;
        public CommonResponse<Guid> ChargeResponse;

        public int NumberTransactions;
        public IWebDriver Driver { get; set; }
        public UsersPage UserPage { get; set; }
        public MainPage MainPage { get; set; }
        public CreateCustomerPage CreateUser { get; set; }

        public BasePage CurrentPage { get; set; }
        public UserInfo UserInfo { get; internal set; }

        public List<string> TittleModalFields;
        public TransactionInfoResponse TransactionInfo { get; internal set; }
        public TransactionInfoResponse RevertTransactionInfo { get; internal set; }

        public CatalogClient CatalogServiceClient { get; set; }

        public List<DateTime> ExpectedTransactionTime { get; internal set; }
        public List<DateTime> ActualTransactionTime { get; internal set; }

        public List<Guid> ExpectedIdsTransaction { get; internal set; }
        public List<double> ExpectedAmountTransaction { get; internal set; }
        public List<string> ExpectedStatusTransaction { get; internal set; }
        public List<TransactionInfoResponse> transactionInfos { get; internal set; }
        public List<string> ProductArticles { get; internal set; }
        public List<(AddProductRequest, ProductStatus)> ProductRequestsAndStatuses { get; internal set; }
        public List<TransactionInfoResponse> ActualTransactionInfos { get; internal set; }
        public List<TransactionInfoResponse> ExpectedTransactionInfos { get; internal set; }
    }
}
