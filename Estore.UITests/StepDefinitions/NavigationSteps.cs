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

        [Given(@"open users page")]
        public void GivenOpenUsersPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:users"]}");
            _context.UserPage = new UsersPage(_context.Driver);
            _context.CurrentPage = _context.UserPage;
            _context.UserPage.LoadUserTable();
        }

        [Given(@"open main page")]
        public void GivenOpenMainPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:main"]}");
            _context.MainPage = new MainPage(_context.Driver);
            _context.CurrentPage = _context.MainPage;
            _context.MainPage.WaitProductsLoading();
        }

        [Given(@"Open login page")]
        public void GivenOpenLoginPage()
        {
            _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:login"]}");
            _context.LoginPage = new LoginPage(_context.Driver);
            _context.CurrentPage = _context.LoginPage;            
        }

        [Given(@"Is Login page open")]
        [When(@"Is Login page open")]
        [Then(@"Login page should be open")]
        public void IsLoginPageOpen()
        {
            string pageTitle = _context.Driver.Title;
            string expectedTitle = "EstoreBlazor";
            if (pageTitle == expectedTitle)
            {
                if(_context.LoginPage == null)
                {
                    _context.LoginPage = new LoginPage(_context.Driver);
                }                
                _context.CurrentPage = _context.LoginPage;
            }
            else
            {
                Assert.Fail("Login page is not open");
            }
        }

        [Given(@"Is Main page open")]
        [When(@"Is Main page open")]
        [Then(@"Main page should be open")]
        public void IsMainPageOpen()
        {
            string pageTitle = _context.Driver.Title;
            string expectedTitle = "EstoreBlazor";
            if (pageTitle == expectedTitle)
            {
                if (_context.MainPage == null)
                {
                    _context.MainPage = new MainPage(_context.Driver);
                }                
                _context.CurrentPage = _context.MainPage;                
            }
            else
            {
                Assert.Fail("Main page is not open");
            }
        }

        [Given(@"Is User page open")]
        [When(@"Is User page open")]
        [Then(@"User page should be open")]
        public void IsUserPageOpen()
        {
            string pageTitle = _context.Driver.Title;
            string expectedTitle = "User";
            if (pageTitle == expectedTitle)
            {
                if (_context.UserPage == null)
                {
                    _context.UserPage = new UsersPage(_context.Driver);
                }
                _context.CurrentPage = _context.UserPage;
            }
            else
            {
                Assert.Fail("User page is not open");
            }
        }
    }
}