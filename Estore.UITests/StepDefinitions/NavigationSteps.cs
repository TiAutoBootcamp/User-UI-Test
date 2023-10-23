using Estore.UITests.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;
using UITests.Pages;

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
            _context.UserPage = new UsersPage(_context.Driver);
            _context.UserPage.LoadUserTable();
        }

        [Given(@"open main page")]
        public void GivenOpenMainPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:main"]}");
            _context.MainPage = new MainPage(_context.Driver);
            _context.MainPage.WaitProductsLoading();
        }

        [Given(@"Open login page")]
        public void GivenOpenLoginPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:login"]}");
            _context.LoginPage = new LoginPage(_context.Driver);                        
        }

        [Given(@"Login page is open")]
        [When(@"Login page is open")]
        [Then(@"Login page should be open")]
        public void LoginPageIsOpen()
        {
            string pageTitle = _context.Driver.Title;
            string expectedTitle = "EstoreBlazor";
            if (pageTitle == expectedTitle)
            {
                if(_context.LoginPage == null)
                {
                    _context.LoginPage = new LoginPage(_context.Driver);
                }                
            }
            else
            {
                Assert.Fail("Login page is not open");
            }
        }

        [Given(@"Main page is open")]
        [When(@"Main page is open")]
        [Then(@"Main page should be open")]
        public void MainPageIsOpen()
        {
            //Need to add waiter 
            //_wait.Until(driver => !driver.Url.Contains("/login")); 
            string pageTitle = _context.Driver.Title;
            string expectedTitle = "EstoreBlazor";
            if (pageTitle == expectedTitle)
            {
                if (_context.MainPage == null)
                {
                    _context.MainPage = new MainPage(_context.Driver);
                }                                
            }
            else
            {
                Assert.Fail("Main page is not open");
            }
        }

        [Given(@"User page is open")]
        [When(@"User page is open")]
        [Then(@"User page should be open")]
        public void UserPageIsOpen()
        {
            string pageTitle = _context.Driver.Title;
            string expectedTitle = "User";
            if (pageTitle == expectedTitle)
            {
                if (_context.UserPage == null)
                {
                    _context.UserPage = new UsersPage(_context.Driver);
                }                
            }
            else
            {
                Assert.Fail("User page is not open");
            }
        }
    }
}