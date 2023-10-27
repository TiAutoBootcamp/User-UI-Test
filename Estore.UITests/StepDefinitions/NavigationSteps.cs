using Estore.UITests.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;
using UITests.Pages;
using UserManagementServiceUITests.Pages;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public sealed class NavigationSteps
    {
        private readonly string _baseUrl;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public NavigationSteps(DataContext context, IConfiguration configuration)
        {
            _baseUrl = configuration["BaseUrl"];
            _context = context;
            _configuration = configuration;
        }

        [Given(@"Open users page")]
        public void OpenUsersPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:users"]}");            
        }

        [Given(@"Open main page")]
        public void OpenMainPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:main"]}");            
        }

        [Given(@"Open login page")]
        public void OpenLoginPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:login"]}");                                    
        }

        [StepDefinition(@"Login page is opened")]
        public void LoginPageIsOpen()
        {
            _context.LoginPage = new LoginPage(_context.Driver);
        }

        [StepDefinition(@"Main page is opened")]
        public void MainPageIsOpen()
        {
            _context.MainPage = new MainPage(_context.Driver);
            _context.MainPage.WaitProductsLoading();
        }

        [StepDefinition(@"User page is opened")]
        public void UserPageIsOpen()
        {
            _context.UserPage = new UsersPage(_context.Driver);
            _context.UserPage.LoadUserTable();            
        }

        [StepDefinition(@"Create user modal window is opened")]
        public void CreateUserModalWindowIsOpen()
        {
            if(_context.UserPage.CreateUserModalIsOpen())
            {
                _context.CreateUser = new CreateUserPage(_context.Driver);
            }
            else
            {
                Assert.Fail("Create user modal window is not open");
            }           
        }
    }
}