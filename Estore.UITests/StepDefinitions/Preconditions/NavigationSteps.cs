using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using UITests.Context;
using UITests.Pages;

namespace Estore.UITests.StepDefinitions.Preconditions
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
    }
}