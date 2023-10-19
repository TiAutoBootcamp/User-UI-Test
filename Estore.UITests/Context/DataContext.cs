using OpenQA.Selenium;
using UITests.Pages;
using UserManagementServiceUITests.Pages;
using Estore.Models.Request.Catalog;
using Estore.Models.Enum;
using Estore.UITests.Pages;

namespace UITests.Context
{
    public class DataContext
    {
        public AddProductRequest ProductRequest { get; set; }
        public IWebDriver Driver { get; set; }
        public UsersPage UserPage { get; set; }
        public MainPage MainPage { get; set; }
        public LoginPage LoginPage { get; set; }
        public CreateUserPage CreateUser { get; set; }
        public BasePage CurrentPage { get; set; }
        public List<string> ProductArticles { get; internal set; }
        public List<(AddProductRequest, ProductStatus)> ProductRequestsAndStatuses { get; internal set; }        
        public string WelcomeMessage { get; set; }
    }
}
