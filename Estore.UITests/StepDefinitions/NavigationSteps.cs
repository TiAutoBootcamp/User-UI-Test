using Estore.UITests.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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

        [Given(@"Open (Main|Users|Login|Orders) page")]
        public void OpenPage(string pageName)
        {
            switch (pageName)
            {
                case "Main":
                    _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:main"]}");
                    break;
                case "Users":
                    _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:users"]}");
                    break;
                case "Login":
                    _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:login"]}");
                    break;
                case "Orders":
                    _context.Driver.Navigate().GoToUrl($"{_baseUrl}{_configuration["Pages:orders"]}");
                    break;
                default:
                    Assert.Fail("Unknown page name");
                    break;
            }                        
        }              

        [StepDefinition(@"(Main|Users|Login|Orders) page is opened")]
        public void PageIsOpened(string pageName)
        {
            switch (pageName)
            {
                case "Main":
                    _context.MainPage = new MainPage(_context.Driver);
                    _context.MainPage.WaitProductsLoading();
                    break;
                case "Users":
                    _context.UserPage = new UsersPage(_context.Driver);
                    _context.UserPage.WaitPageLoading();
                    break;
                case "Login":
                    _context.LoginPage = new LoginPage(_context.Driver);
                    break;
                case "Orders":
                    _context.OrdersPage = new OrdersPage(_context.Driver);
                    break;
                default:
                    Assert.Fail("Unknown page name");
                    break;
            }            
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