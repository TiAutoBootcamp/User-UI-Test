using TechTalk.SpecFlow;
using UITests.Pages;

namespace UITests.StepDefinitions
{
    [Binding]
    public sealed class NavigationSteps
    {
        private readonly DataContext _context;

        public NavigationSteps(DataContext context)
        {
            _context = context;
        }

        [Given(@"open users page")]
        public void GivenOpenUsersPage()
        {
            _context.Driver.Navigate().GoToUrl("https://estore-uat.azurewebsites.net/users");

            _context.UserPage = new UserPage(_context.Driver);
            _context.CurrentPage = _context.UserPage;
            _context.UserPage.LoadUserTable();
        }

            _context.CreateUser = new CreatePage(_context.Driver);
        [Given(@"open main page")]
        public void GivenOpenMainPage()
        {
            _context.Driver.Navigate().GoToUrl("https://estore-uat.azurewebsites.net/main");
            _context.MainPage = new MainPage(_context.Driver);
            _context.CurrentPage = _context.MainPage;
            _context.MainPage.WaitProductsLoading();
        }
    }
}