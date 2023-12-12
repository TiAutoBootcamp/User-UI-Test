using OpenQA.Selenium;
using UITests.Pages;
using UserManagementServiceUITests.Pages;
using Estore.Models.Request.Catalog;
using Estore.Models.Enum;
using Estore.UITests.Pages;
using Estore.Models.DataModels.User;
using Estore.CoreAdditional.Models;

namespace UITests.Context
{
    public class DataContext
    {
        private UsersPage _userPage;
        private MainPage _mainPage;
        private LoginPage _loginPage;
        private CreateUserPage _createUser;
        private OrdersPage _ordersPage;
        public IWebDriver Driver { get; set; }
        public UsersPage UserPage 
        {
            get
            {
                return _userPage;
            }
            set
            {
                _userPage = value;
                CurrentPage = value;
            }
        }

        public MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
            set
            {
                _mainPage = value;
                CurrentPage = value;
            }
        }

        public LoginPage LoginPage
        {
            get
            {
                return _loginPage;
            }
            set
            {
                _loginPage = value;
                CurrentPage = value;
            }
        }

        public CreateUserPage CreateUser
        {
            get
            {
                return _createUser;
            }
            set
            {
                _createUser = value;
                CurrentPage = value;
            }
        }
        public OrdersPage OrdersPage
        {
            get
            {
                return _ordersPage;
            }
            set
            {
                _ordersPage = value;
                CurrentPage = value;
            }
        }

        public BasePage CurrentPage { get; private set; }
        public UserModel CurrentUser { get; set; }
        public string CurrentUserToken { get; set; }
        public IList<int> RegisteredCustomers { get; set; }
        public AddProductRequest ProductRequest { get; set; }
        public List<string> ProductArticles { get; internal set; }
        public List<(AddProductRequest, ProductStatus)> ProductRequestsAndStatuses { get; internal set; } 
        public byte[] CurrentProductImage { get; set; }
        public IList<OrderInfo> CreatedOrders { get; set; }
    }
}
