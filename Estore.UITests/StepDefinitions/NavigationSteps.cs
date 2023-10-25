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
        public void GivenOpenUsersPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:users"]}");            
        }

        [Given(@"Open main page")]
        public void GivenOpenMainPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:main"]}");            
        }

        [Given(@"Open login page")]
        public void GivenOpenLoginPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:login"]}");                                    
        }

        [Given(@"Login page is open")]
        [When(@"Login page is open")]
        [Then(@"Login page should be open")]
        public void LoginPageIsOpen()
        {
            _context.LoginPage = new LoginPage(_context.Driver);
        }

        [Given(@"Main page is open")]
        [When(@"Main page is open")]
        [Then(@"Main page should be open")]
        public void MainPageIsOpen()
        {
            _context.MainPage = new MainPage(_context.Driver);
            _context.MainPage.WaitProductsLoading();
        }

        [Given(@"User page is open")]
        [When(@"User page is open")]
        [Then(@"User page should be open")]
        public void UserPageIsOpen()
        {
            _context.UserPage = new UsersPage(_context.Driver);
            _context.UserPage.LoadUserTable();            
        }

        [Given(@"Create user modal window is open")]
        [When(@"Create user modal window is open")]
        [Then(@"Create user modal window should be open")]
        public void GivenCreateUserModalWindowIsOpen()
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

        [Then(@"Create user modal window should be close")]
        public void ThenCreateUserModalWindowShouldBeClose()
        {
            Assert.IsTrue(_context.UserPage.CreateUserModalIsClosed());
        }
    }
}